using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kokteilController : MonoBehaviour {

    public float Speed = 3f;

    static public List<kokteilController> Bullets = new List<kokteilController>();
    public kokteilController next;
    protected Animator _anim;
    public string EnemyTag;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("Die", false);
        if (Bullets.Count == 0)
        {
            next = this;
            DuremarController.Fire += Fire;
        }
        else
        {
            Bullets[Bullets.Count - 1].next = this;
            next = Bullets[0];
        }
        Bullets.Add(this);
        gameObject.renderer.enabled = false;
    }

    void Fire(Vector2 position, Vector2 direction)
    {
        rigidbody2D.isKinematic = true;
        transform.position = position;
        rigidbody2D.isKinematic = false;
        gameObject.renderer.enabled = true;
        rigidbody2D.velocity = direction * Speed;
        DuremarController.Fire -= Fire;
        DuremarController.Fire += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(DieAnimate());

    }



    protected IEnumerator DieAnimate()
    {
        //rigidbody2D.isKinematic = true;
        _anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.3f);
        //gameObject.SetActive(false);
        _anim.SetBool("Die", false);
        gameObject.renderer.enabled = false;
    }
}
