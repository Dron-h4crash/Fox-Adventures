using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class Winner1script : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<InputField>().text = string.Format("{0:D}", string.IsNullOrEmpty(PlayerPrefs.GetString("WinCurrName")) ? "Игрок" : PlayerPrefs.GetString("WinCurrName"));
    }

   

    public void ChangeName()
    {
        PlayerPrefs.SetString("WinCurrName", gameObject.GetComponent<Text>().text);
    }

    public void quit()
    {
        Application.LoadLevel(0);
    }
    
	
}
