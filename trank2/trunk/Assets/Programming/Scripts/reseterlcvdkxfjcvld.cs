using UnityEngine;
using System.Collections;

public class reseterlcvdkxfjcvld : MonoBehaviour {

	
	void Start () {
        Destroy(GameObject.Find("GUI"));
        Destroy(GameObject.Find("Game Controllers"));
        Destroy(GameObject.Find("Weapons"));
        WeaponManager.resAmm();
        HeroController.Fire = null;
        HeroController.Fire1 = null;
        HeroController.Fire2 = null;
        HeroController.Fire3 = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
