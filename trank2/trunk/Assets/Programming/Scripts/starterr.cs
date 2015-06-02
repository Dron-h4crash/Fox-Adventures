using UnityEngine;
using System.Collections;

public class starterr : MonoBehaviour {

    public GameObject sa;

    public static GameObject ss;

	void Start () {
        if (ss == null)
        {
            Instantiate(sa);
            DontDestroyOnLoad(sa);
            ss = sa;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
