using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

	public Rect playGameRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 75);
	public Rect quitRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 + 50, 400, 75); 
	public void OnGUI()
	{
		
				if (GUI.Button(playGameRect, "Уровень 1"))
				{
					Application.LoadLevel("StartScene");
				}
				if (GUI.Button(quitRect, "Quit"))
				{
					Application.Quit();
				}
			
	}
}
