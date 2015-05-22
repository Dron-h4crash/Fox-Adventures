using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bests : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var kol = PlayerPrefs.GetInt("colWiners");
        var winers = "";
        for (int i = 1; i < kol; i++)
        {
            winers += PlayerPrefs.GetString("winname" + i.ToString()) + "---" + PlayerPrefs.GetInt("winres" + i.ToString()).ToString() + "\n";
        }

        gameObject.GetComponent<Text>().text = winers;
	}
	
	// Update is called once per frame
	void Update () {
        var kol = PlayerPrefs.GetInt("colWiners");
        var winers = "";
        for (int i = 1; i < kol; i++)
        {
            winers += PlayerPrefs.GetString("winname" + i.ToString()) + "---" + PlayerPrefs.GetInt("winres" + i.ToString()).ToString() + "\n";
        }

        gameObject.GetComponent<Text>().text = winers;
	}
}
