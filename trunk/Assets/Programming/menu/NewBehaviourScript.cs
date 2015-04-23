using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GUIStyle welcomeLabel; 

    public GUISkin customSkin;
	private Rect playGameRect = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 - Screen.height / 8, Screen.width / 2, Screen.height / 5);     
    //public Rect optionsRect;      
	private Rect quitRect = new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 + Screen.height / 8, Screen.width / 2, Screen.height / 5);        

	//private bool optionsMode = false;
    private bool menuMode = true;   //1
    private bool gameMode = false;  //1


    public float _bulletImpulse  = 300;
    public float _shootDelay   = 1;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
    public void OnGUI()
    {
        if (Input.GetKey(KeyCode.Escape))
        {  //2
            menuMode = true;               
            //optionsMode = false;
            Time.timeScale = 0;           

            if (gameMode)
            {
                //var ml = GameObject.Find("HeroController").GetComponent(MouseLook);  
                //ml.enabled = false;  
            }
        }

        if (menuMode)
        {
            //if (!optionsMode)
            //{

                //GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Welcome", welcomeLabel);

                GUI.skin = customSkin;

                if (!gameMode)
                {              
                    //if (GUI.Button(playGameRect, "Play Game"))
					if (GUI.Button(playGameRect, "Play Game"))
                    {
                        menuMode = false;   
                        gameMode = true;    
                        Time.timeScale = 1; 
                        Application.LoadLevel("StartScene");
                    }
                }
                else
                {
					if (GUI.Button(playGameRect, "Resume"))
                    {
                        //var _ml = GameObject.Find("HeroController").GetComponent(MouseLook);//4
                        //_ml.enabled = true; //4
                        Time.timeScale = 1; //3
                        menuMode = false;   //1
                    }
                }

                //if (GUI.Button(optionsRect, "Options"))
                //{
                //    optionsMode = true;
                //}

                if (GUI.Button(quitRect, "Quit"))
                {
                    Application.Quit();
                }

           // }
            //else
            //{

            //    GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Options", welcomeLabel);

            //    GUI.skin = customSkin;

            //    GUI.Label(new Rect(270, 75, 50, 20), "Bullet Impulse");
            //    _bulletImpulse = GUI.HorizontalSlider(new Rect(50, 100, 500, 20), _bulletImpulse, 10, 700);
            //    GUI.Label(new Rect(560, 95, 50, 20), _bulletImpulse.ToString());

            //    GUI.Label(new Rect(270, 125, 50, 20), "Shoot Delay");
            //    _shootDelay = GUI.HorizontalSlider(new Rect(50, 150, 500, 20), _shootDelay, 1/10, 3);
            //    GUI.Label(new Rect(560, 145, 50, 20), _shootDelay.ToString());

            //    if (GUI.Button(new Rect(20, 190, 100, 30), "<< Back"))
            //    {
            //        optionsMode = false;
            //    }

            //}
        }   //4
	}
}
