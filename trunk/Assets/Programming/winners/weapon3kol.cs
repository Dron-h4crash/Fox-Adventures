using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class weapon3kol : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<Text>().text = string.Format("X {0:D}", PlayerPrefs.GetInt("WinWeapon3").ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
