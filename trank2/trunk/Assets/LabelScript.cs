using UnityEngine;
using System.Collections;

public class LabelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(LabelShow());
	}

	protected IEnumerator LabelShow()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
