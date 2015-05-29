using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButulkaWeaponManager : MonoBehaviour
{

    public float Speed = 2f;

    static public List<ButulkaWeaponManager> Bullets = new List<ButulkaWeaponManager>();
    public ButulkaWeaponManager next;
    protected Animator _anim;
    public string EnemyTag;
    public AudioClip clip1;
    public AudioClip clip2;
    AudioSource audio;

    void Start()
    {
        DontDestroyOnLoad(this);
        _anim = GetComponent<Animator>();
        _anim.Play("vreschzButulka");
        if (Bullets.Count == 0)
        {
            next = this;
            WeaponManager.Fire1 += Fire;
        }
        else
        {
            Bullets[Bullets.Count - 1].next = this;
            next = Bullets[0];
        }
        Bullets.Add(this);
        gameObject.renderer.enabled = false;

        audio = GetComponent<AudioSource>();
    }

    Vector2 tdirection = new Vector2();
    bool one = false;
    void Fire(Vector2 position, Vector2 direction)
    {
        if (audio != null)
        {
            audio.clip = clip1;
            audio.Play();
        }
        one = true;


        rigidbody2D.isKinematic = true;
        transform.position = position;
        rigidbody2D.isKinematic = false;
        gameObject.renderer.enabled = true;
        rigidbody2D.velocity = direction * Speed;
        tdirection = direction;
        WeaponManager.Fire1 -= Fire;
        WeaponManager.Fire1 += next.Fire;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Butulka")
        {
            rigidbody2D.velocity = tdirection * Speed;
            Physics2D.IgnoreCollision(gameObject.collider2D, other.gameObject.collider2D, true);
        }
        else
            StartCoroutine(DieAnimate());

    }



    protected IEnumerator DieAnimate()
    {
        var audio = GetComponent<AudioSource>();
        audio.clip = clip2;
        if (one)
        {
            audio.Play();
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
