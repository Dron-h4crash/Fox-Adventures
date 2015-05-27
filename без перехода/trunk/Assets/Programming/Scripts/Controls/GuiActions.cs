using UnityEngine;
using System.Collections;
using System;

public class GuiActions : MonoBehaviour {

	public static Action NextWeapon;
    public static Action Jump;
    public static Action Left;
    public static Action Right;
    public static Action Stop;
    public static Action <bool> Attack;

	// Use this for initialization
	void Start () {
	
	}

	public void SelectNextWeapon()
	{
		if(NextWeapon != null) NextWeapon();
	}

    public void SelectStop()
    {
        if (Stop != null) Stop();
    }

    public void SelectStartAttack(bool on)
    {
        if (Attack != null) Attack(on);
    }

    public void SelectJump()
    {
        if (Jump != null) Jump();
    }

    public void SelectLeft()
    {
        if (Left != null) Left();
    }

    public void SelectRight()
    {
        if (Right != null) Right();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
