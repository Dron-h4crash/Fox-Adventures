using UnityEngine;

public class SmoothCamera2D : MonoBehaviour
{
    public float DampTime = 0.05f;
    public Vector3 staticDelta;
    public Transform Target;

    Vector3 pos;

    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        if (!Target) return;
        pos = Target.position;
    }

    void Update()
    {
        Target = GameObject.Find("MainHero").transform;
        if (!Target) return;

        //if (!HeroController.Instance.IsGrounded) pos = new Vector2(Target.position.x, pos.y);
        /*else*/ pos = Target.position;

        var point = camera.WorldToViewportPoint(pos);
        var delta = pos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        var destination = transform.position + delta + staticDelta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, DampTime);
    }
}
