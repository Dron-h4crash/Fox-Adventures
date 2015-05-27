using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float SpeedX = 1f;
    public Vector2 StartSpeed = -Vector2.right;

    protected HPManager _health;

    protected bool _isFacingRight;
    protected Animator _anim;

    void Start()
    {
        _health = GetComponent<HPManager>();
        _anim = GetComponent<Animator>();
        rigidbody2D.velocity = StartSpeed;
        StartCoroutine(Moving());
    }

    protected virtual IEnumerator Moving()
    {
        while (Application.isPlaying)
        {
            //if (_health.Hp > 0)
            //{
            //   // rigidbody2D.AddForce(Vector2.up * WingsForce);
            //    if (_anim.GetCurrentAnimationClipState(0).Length > 0)
            //        yield return new WaitForSeconds(CircleLength * _anim.GetCurrentAnimationClipState(0)[0].clip.length);
            //    else yield return new WaitForSeconds(19f/30f); // длина анимации взмаха крыла 19 кадров, 30 кадров в секунду
            //    rigidbody2D.AddForce(Vector2.up * WingsForce);
            //}
            yield return new WaitForEndOfFrame();
        }
    }

    protected virtual void FixedUpdate()
    {
        if(_health.Hp < 1)
        {
            rigidbody2D.velocity = Vector2.zero;
            return;
        }
        var speed = rigidbody2D.velocity;

        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f) rigidbody2D.velocity = new Vector2(speed.x > 0f ? SpeedX : -SpeedX, speed.y);
        if (speed.x > 0f && !_isFacingRight || speed.x < 0f && _isFacingRight) Flip();
    }

    protected void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public virtual void HpChangedMessage(int hp)
    {
        Debug.Log(string.Format("{0} hp: {1}", name, hp));
    }

    public virtual void DamageReceived()
    {
        StartCoroutine(DamageAnimate());
    }

    protected IEnumerator DamageAnimate()
    {
        //rigidbody2D.isKinematic = true;
        _anim.SetBool("Damage",true);
        yield return new WaitForSeconds(0.15f);
        _anim.SetBool("Damage", false);
    }

    public void Die()
    {
        StartCoroutine(DieAnimate());
    }

    protected IEnumerator DieAnimate() 
    {
        //rigidbody2D.isKinematic = true;
        _anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        rigidbody2D.velocity = coll.contacts[0].normal; // сменить скорость на противоположную точке соприкосновения
    }
}
