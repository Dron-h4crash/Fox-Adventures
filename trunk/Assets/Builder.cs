using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var StartPoint = GameObject.FindGameObjectWithTag("Startpoint");
        var Objects = GameObject.FindGameObjectsWithTag("MainHero");
        foreach (GameObject gameObj in Objects)
        {
            gameObj.transform.position = StartPoint.transform.position;
            gameObj.GetComponent<HPManager>().SetStartHP();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
