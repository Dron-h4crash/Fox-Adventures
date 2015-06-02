using UnityEngine;
using System.Collections;

public class Menuresetter : MonoBehaviour {


    public static GameObject tt;
	// Use this for initialization
	void Start () {
         tt = GameObject.Find("Weapons");
        GameObject[] ww = GameObject.FindGameObjectsWithTag("WEAPON");
        for (int i = 0; i < ww.Length; i++)
        {
            if (ww[i]!=tt)
            Destroy(ww[i]);
        }

	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
