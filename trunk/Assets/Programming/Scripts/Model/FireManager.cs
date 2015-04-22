using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    Animator _anim;
    public Vector2 delta = Vector2.zero;

    private bool _isFacingRight = true;

    void Start()
    {
        WeaponManager.Fire += Fire;
        _anim = GetComponent<Animator>();
    }

    public void Fire(Vector2 position, Vector2 direction)
    {
        if (direction.x > 0f && !_isFacingRight || direction.x < 0f && _isFacingRight) Flip();
        transform.position = position + delta;
        _anim.Play("fire");
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        delta *= -1f;
        transform.localScale = theScale;
    }
}
