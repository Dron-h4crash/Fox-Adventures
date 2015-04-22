using UnityEngine;
using System.Collections;

public class butulka1Manager : MonoBehaviour {

    public string HeroTag;
    public int type;
    public int count = 1;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == HeroTag)
        {
            gameObject.renderer.enabled = false;
            Destroy(gameObject);
            other.gameObject.SendMessageUpwards("AddButulka"+type.ToString(), count);
        }
    }
}
