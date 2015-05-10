using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kolobokButulkaMemeger : MonoBehaviour {

    public float Speed = 3f;

    static public List<kolobokButulkaMemeger> Bullets = new List<kolobokButulkaMemeger>();
    public kolobokButulkaMemeger next;
    protected Animator _anim;
    public string EnemyTag;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("Die", false);
        if (Bullets.Count == 0)
        {
            next = this;
            KolobokKontroller.Fire += Fire;
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
        KolobokKontroller.Fire -= Fire;
        KolobokKontroller.Fire += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(DieAnimate());
        Debug.Log("df");

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
