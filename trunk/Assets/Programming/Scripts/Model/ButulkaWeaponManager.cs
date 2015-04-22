using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButulkaWeaponManager : MonoBehaviour {

    public float Speed = 2f;

    static public List<ButulkaWeaponManager> Bullets = new List<ButulkaWeaponManager>();
    public ButulkaWeaponManager next;

    void Start()
    {
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
    }

    void Fire(Vector2 position, Vector2 direction, int type)
    {
        rigidbody2D.isKinematic = true;
        transform.position = position;
        rigidbody2D.isKinematic = false;
        gameObject.renderer.enabled = true;
        rigidbody2D.velocity = direction * Speed;
        WeaponManager.Fire1 -= Fire;
        WeaponManager.Fire1 += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.renderer.enabled = false;
    }
}
