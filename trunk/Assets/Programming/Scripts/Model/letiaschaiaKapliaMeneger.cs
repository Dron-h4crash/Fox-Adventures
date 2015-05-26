using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class letiaschaiaKapliaMeneger : MonoBehaviour {
    
    static public List<letiaschaiaKapliaMeneger> Bullets = new List<letiaschaiaKapliaMeneger>();
    public letiaschaiaKapliaMeneger next;
    protected Animator _anim;
    public string EnemyTag;
    public Transform kapliaEnd;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("3");
        if (Bullets.Count == 0)
        {
            next = this;
            kapliaController.Fire += Fire;
        }
        else
        {
            Bullets[Bullets.Count - 1].next = this;
            next = Bullets[0];
        }
        Bullets.Add(this);
        gameObject.renderer.enabled = false;
    }

    void Fire(Vector2 position)
    {
		if (_anim!=null)
			_anim.Play("3");
        rigidbody2D.isKinematic = true;
        transform.position = position;
        transform.rotation = new Quaternion();
        rigidbody2D.isKinematic = false;
        gameObject.renderer.enabled = true;
        kapliaController.Fire -= Fire;
        kapliaController.Fire += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _anim.Play("4");
        
        StartCoroutine(DieAnimate());

    }



    protected IEnumerator DieAnimate()
    {
        _anim.SetBool("inGround", true);
        yield return new WaitForSeconds(0.45f);
        transform.position = kapliaEnd.position;
        gameObject.renderer.enabled = false;
    }
}

