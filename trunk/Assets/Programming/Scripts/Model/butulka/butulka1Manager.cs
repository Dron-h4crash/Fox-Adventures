using UnityEngine;
using System.Collections;

public class butulka1Manager : MonoBehaviour {

    public string HeroTag;
    public int type;
    public int count = 1;

	//void Start()
	//{
	//	var enemies = GameObject.FindWithTag("Enemy");
	//	Physics.IgnoreCollision(gameObject.collider, enemies.collider);
	//}

    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == HeroTag)
		{
			gameObject.renderer.enabled = false;
			Destroy(gameObject);
			other.gameObject.SendMessageUpwards("AddButulka" + type.ToString(), count);
		}
		else
		{
			Physics2D.IgnoreCollision(gameObject.collider2D, other.gameObject.collider2D);
		}
    }

}
