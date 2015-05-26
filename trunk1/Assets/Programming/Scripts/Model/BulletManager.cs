using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour
{
    public float Speed = 5f;

    static public List<BulletManager> Bullets = new List<BulletManager>();
    public BulletManager next;

    void Start()
    {
        if (Bullets.Count == 0) 
        { 
            next = this;
            WeaponManager.Fire += Fire;
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
        WeaponManager.Fire -= Fire;
        WeaponManager.Fire += next.Fire;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.renderer.enabled = false;
    }
}
