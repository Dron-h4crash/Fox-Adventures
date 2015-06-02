using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boss3weapon : MonoBehaviour
{

    public float Speed = 3f;

    static public List<boss3weapon> Bullets = new List<boss3weapon>();
    public boss3weapon next;
    protected Animator _anim;
    public string EnemyTag;
    public AudioClip clip1;
    public AudioClip clip2;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetBool("Die", false);
        if (Bullets.Count == 0)
        {
            next = this;
            boss3controller.Fire += Fire;
        }
        else
        {
            Bullets[Bullets.Count - 1].next = this;
            next = Bullets[0];
        }
        Bullets.Add(this);
        gameObject.renderer.enabled = false;
    }
    bool one = false;
    void Fire(Vector2 position, Vector2 direction)
    {
        var audio = GetComponent<AudioSource>();
        audio.clip = clip1;
        audio.Play();
        one = true;
        rigidbody2D.isKinematic = true;
        transform.position = position;
        rigidbody2D.isKinematic = false;
        gameObject.renderer.enabled = true;
        rigidbody2D.velocity = direction * Speed;
        boss3controller.Fire -= Fire;
        boss3controller.Fire += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(DieAnimate());

    }



    protected IEnumerator DieAnimate()
    {
        var audio = GetComponent<AudioSource>();
        audio.clip = clip2;
        if (one)
        {
            audio.Play();
            audio.volume = 0.1f;
            one = false;
        }
        //rigidbody2D.isKinematic = true;
        _anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.3f);
        //gameObject.SetActive(false);
        _anim.SetBool("Die", false);
        gameObject.renderer.enabled = false;
    }
}
