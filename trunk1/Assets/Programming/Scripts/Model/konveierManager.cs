using UnityEngine;
using System.Collections;

public class konveierManager : MonoBehaviour
{

	public string HeroTag;
	public bool left = true;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == HeroTag)
		{
			other.gameObject.SendMessageUpwards("KoveyerMove", left);
		}

	}

}
