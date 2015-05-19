using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bests : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var kol = PlayerPrefs.GetInt("colWiners");
        Debug.Log(kol);
        var winers = "";
        for (int i = 0; i < kol; i++)
        {
            Debug.Log(PlayerPrefs.GetString("winname" + i.ToString()));
            winers += PlayerPrefs.GetString("winname" + i.ToString()) + "---" + PlayerPrefs.GetInt("winres" + i.ToString()).ToString() + "\n";
        }

        gameObject.GetComponent<Text>().text = winers;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
