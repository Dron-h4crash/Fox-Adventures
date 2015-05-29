using UnityEngine;
using System.Collections;

public class DestroyerHero : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var Objects = GameObject.FindGameObjectsWithTag("MainHero");
        foreach (GameObject gameObj in Objects)
        {
            DestroyImmediate(gameObj);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
