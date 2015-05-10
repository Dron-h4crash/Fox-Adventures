using UnityEngine;
using System.Collections;

public class GameOver1 : MonoBehaviour {

	private Rect playGameRect = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 8, Screen.width / 2, Screen.height / 5);
	//public Rect optionsRect;      
	private Rect quitRect = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 + Screen.height / 8, Screen.width / 2, Screen.height / 5); 
	public void OnGUI()
	{

        //if (GUI.Button(playGameRect, "Уровень 1"))
        //{
        //    Application.LoadLevel("StartScene");
        //}
		if (GUI.Button(quitRect, "ВЫХОД"))
		{
			Application.Quit();
		}

	}
}
