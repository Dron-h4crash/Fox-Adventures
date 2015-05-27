using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Text>().text = string.Format("Ваш результат {0:D}", PlayerPrefs.GetInt("CurrentScore"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
