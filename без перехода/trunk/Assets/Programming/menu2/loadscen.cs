using UnityEngine;
using System.Collections;

public class loadscen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var loadingLevel = PlayerPrefs.GetInt("loadingLevel");
        Application.LoadLevel(loadingLevel);
	}
	
	
}
