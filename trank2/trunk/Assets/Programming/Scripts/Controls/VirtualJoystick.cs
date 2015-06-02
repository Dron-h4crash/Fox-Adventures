using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class VirtualJoystick : MonoBehaviour
{
    public static Action Right;
    public static Action Left;
    public static Action Stop;
//    public static Action Up;
    public static Action Down;
    public Text Movement;

    private bool isControllable = true;
    [HideInInspector]
    public Vector2 movement = Vector2.zero;
    private Vector2 prevMovement = Vector2.zero;

    //private Texture2D padBackgroundTexture;
    //private Texture2D padControllerTexture;
 //   private Rect padBackgroundRect = new Rect(0, 0, 100, 100);
//    private Rect padControllerRect = new Rect(0, 0, 100, 100);

    private Vector2 padBackgroundPosition = Vector2.zero;
    private Vector2 padControllerPosition = Vector2.zero;
    private const float padRadius = 50.0f;

//    private bool isMovingFinger = false;

    public void Awake()
    {
        //this.padBackgroundTexture = new Texture2D(1, 1);
        //this.padBackgroundTexture.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.5f));
        //this.padBackgroundTexture.Apply();

        //this.padControllerTexture = new Texture2D(1, 1);
        //this.padControllerTexture.SetPixel(0, 0, new Color(1f, 1f, 1f));
        //this.padControllerTexture.Apply();
    }

    public void Update()
    {
        if (this.isControllable && Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector2 touchPosition = new Vector2(touch.position.x, Screen.height - touch.position.y);

            switch (touch.phase)
            {
                case TouchPhase.Began:
 //                   this.isMovingFinger = true;
                    this.padBackgroundPosition = touchPosition;
                    this.padControllerPosition = touchPosition;
                    break;

                case TouchPhase.Moved:
                    this.padControllerPosition = touchPosition;
                    float padsDistance = Vector2.Distance(this.padBackgroundPosition, this.padControllerPosition);
                    if (padsDistance > padRadius)
                    {
                        //Vector2 padDirection = this.padControllerPosition - this.padBackgroundPosition;
                        float t = padRadius / padsDistance;
                        this.padBackgroundPosition = Vector2.Lerp(this.padControllerPosition, this.padBackgroundPosition, t);
                    }
                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Canceled:
                    if (Stop != null) Stop();
//                    this.isMovingFinger = false;
                    this.padBackgroundPosition = this.padControllerPosition;
                    break;

                case TouchPhase.Ended:
                    if( Stop != null) Stop();
//                    this.isMovingFinger = false;
                    this.padBackgroundPosition = this.padControllerPosition;
                    break;
            }
        }

        Vector2 direction = (this.padControllerPosition - this.padBackgroundPosition);
        float distance = Vector2.Distance(this.padControllerPosition, this.padBackgroundPosition);

        if (padRadius / distance > 3.5f) this.movement = Vector2.zero;
        else
        {
            this.movement = direction.normalized;
            if (padRadius / distance > 1.5f) this.movement /= 2.0f;
        }

        if ((prevMovement - movement).sqrMagnitude > 0.05f && ((this.padControllerPosition.x * 2) < Screen.width))
        {
            if (Movement != null) Movement.text = string.Format("Movement: {0:F3}, {1:F3}", movement.x, movement.y);
            if (movement.x > 0.3f && Right != null) Right();
            if (movement.x < -0.3f && Left != null) Left();
            if (movement.y > 0.3f && Down != null) Down();
//            if (Mathf.Abs(movement.x) < 0.3f && Stop != null) Stop();
            prevMovement = movement;
        }
    }

    public void SetIsControllable(bool isControllable)
    {
        this.isControllable = isControllable;
    }

    public bool GetIsControllable()
    {
        return this.isControllable;
    }

    //public void OnGUI()
    //{
    //    if (this.isMovingFinger && this.isControllable)
    //    {
    //        Rect backgroundRect = new Rect(
    //            this.padBackgroundPosition.x - (this.padBackgroundRect.width / 2.0f),
    //            this.padBackgroundPosition.y - (this.padBackgroundRect.height / 2.0f),
    //            this.padBackgroundRect.width,
    //            this.padBackgroundRect.height
    //        );

    //        Rect controllerRect = new Rect(
    //            this.padControllerPosition.x - (this.padControllerRect.width / 2.0f),
    //            this.padControllerPosition.y - (this.padControllerRect.height / 2.0f),
    //            this.padControllerRect.width,
    //            this.padControllerRect.height
    //        );

    //        GUI.DrawTexture(backgroundRect, this.padBackgroundTexture);
    //        GUI.DrawTexture(controllerRect, this.padControllerTexture);
    //    }
    //}
}
