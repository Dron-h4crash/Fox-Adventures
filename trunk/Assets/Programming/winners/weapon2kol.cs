using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class weapon2kol : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<Text>().text = string.Format("X {0:D}", PlayerPrefs.GetInt("WinWeapon2").ToString());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
