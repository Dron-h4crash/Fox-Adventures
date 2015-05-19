using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class butulkaWeapon2Manager : MonoBehaviour
{

	public float Speed = 2f;

	static public List<butulkaWeapon2Manager> Bullets = new List<butulkaWeapon2Manager>();
	public butulkaWeapon2Manager next;
	protected Animator _anim;
	public string EnemyTag;

	void Start()
	{
		_anim = GetComponent<Animator>();
		_anim.Play("vreschzButulka");
		if (Bullets.Count == 0)
		{
			next = this;
			WeaponManager.Fire2 += Fire;
		}
		else
		{
			Bullets[Bullets.Count - 1].next = this;
			next = Bullets[0];
		}
		Bullets.Add(this);
		gameObject.renderer.enabled = false;
	}
    Vector2 tdirection = new Vector2();
	void Fire(Vector2 position, Vector2 direction)
	{
		rigidbody2D.isKinematic = true;
		transform.position = position;
		rigidbody2D.isKinematic = false;
		gameObject.renderer.enabled = true;
        tdirection = direction;
		rigidbody2D.velocity = direction * Speed;
		WeaponManager.Fire2 -= Fire;
		WeaponManager.Fire2 += next.Fire;
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
		//rigidbody2D.isKinematic = true;
		_anim.SetBool("Die", true);
		yield return new WaitForSeconds(0.3f);
		//gameObject.SetActive(false);
		_anim.SetBool("Die", false);
		gameObject.renderer.enabled = false;
	}
}
