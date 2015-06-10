using UnityEngine;
using System.Collections;
using System;

public class KeyboardInput : MonoBehaviour
{

    public static Action Right;
    public static Action Left;
    public static Action Down;
    public static Action Stop;
    public static Action Jump;
	public static Action NextWeapon;
    public static Action<bool> Attack;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && Right != null) Right();
        if ((Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A)) && Left != null) Left();
		if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && Stop != null) Stop();
		if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) && NextWeapon != null) NextWeapon();
        //if (Input.GetKeyDown(KeyCode.Alpha2) && SelectWeapon != null) SelectWeapon(WeaponManager.HeroWeapons.Pistol);
        if (Input.GetKeyDown(KeyCode.Space) && Jump != null) Jump();
        //if (Input.GetKeyUp(KeyCode.DownArrow)) Down(false);
        //if (Input.GetKeyDown(KeyCode.UpArrow)) Up(true);
        //if (Input.GetKeyUp(KeyCode.UpArrow)) Up(false);
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && Attack != null) Attack(true);
        if ((Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)) && Attack != null) Attack(false);
    }
}
