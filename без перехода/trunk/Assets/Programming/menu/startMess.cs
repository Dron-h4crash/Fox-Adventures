using UnityEngine;
using System.Collections;

public class startMess : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(StartMess());

	}
    private Rect playGameRect = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 8, Screen.width / 2, Screen.height / 5);
    protected IEnumerator StartMess()
    {
        GUI.Label(playGameRect,"asadadad");
        yield return new WaitForSeconds(5f);
    }
	
}
