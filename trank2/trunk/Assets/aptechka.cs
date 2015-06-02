using UnityEngine;
using System.Collections;

public class aptechka : MonoBehaviour {
    public string HeroTag;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == HeroTag)
        {

            Destroy(gameObject);
        }
        else
        {
            Physics2D.IgnoreCollision(gameObject.collider2D, other.gameObject.collider2D);
        }
    }
}
