using UnityEngine;
using System.Collections;

public class noCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		
			Physics2D.IgnoreCollision(gameObject.collider2D, other.gameObject.collider2D);
		
	}
}
