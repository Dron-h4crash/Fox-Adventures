using UnityEngine;
using System.Collections;
using System;

public class WeaponManager : MonoBehaviour {

	public static Action<HeroWeapons> WeaponChanged;
    public static Action<Vector2, Vector2> Fire;
    public static Action<Vector2, Vector2> Fire1;
	public static Action<Vector2, Vector2> Fire2;
	public static Action<Vector2, Vector2> Fire3;
    public static Action<int> AmmoChanged;
    public static Action<int> Ammo1Changed;
    public static Action<int> Ammo2Changed;
    public static Action<int> Ammo3Changed;

    public static WeaponManager Instance;

    public int StartAmmo = 20;
    public int StartAmmobut1 = 10;
    public int StartAmmobut2 = 0;
    public int StartAmmobut3 = 0;

    static int _currentAmmo;
    static int _currentAmmo1;
    static int _currentAmmo2;
    static int _currentAmmo3;

    public static void resAmm()
    {
        Fire = null;
        Fire1 = null;
        Fire2 = null;
        Fire3 = null;

        _currentAmmo = 0;
        _currentAmmo1 = 0;
        _currentAmmo2 = 0;
        _currentAmmo3 = 0;
    }

    public AudioClip clip;

    public void Awake()
    {
       //DontDestroyOnLoad(this.gameObject);
    }

    public int CurrentAmmo
    {
        get { return _currentAmmo; }
        private set { 
            if (value < 0) return; _currentAmmo = value; if (AmmoChanged != null) AmmoChanged(_currentAmmo);
            
        } 
    }

    public int CurrentAmmo1
    {
        get { return _currentAmmo1; }
        private set { if (value < 0) return; _currentAmmo1 = value; if (Ammo1Changed != null) Ammo1Changed(_currentAmmo1);
        if (_currentAmmo1 == 0)
        {
            NextWeapon();
        }
        }
    }
    public int CurrentAmmo2
    {
        get { return _currentAmmo2; }
        private set { if (value < 0) return; _currentAmmo2 = value; if (Ammo2Changed != null) Ammo2Changed(_currentAmmo2);
        if (_currentAmmo2 == 0)
        {
            NextWeapon();
        }
        }
    }
    public int CurrentAmmo3
    {
        get { return _currentAmmo3; }
        private set { if (value < 0) return; _currentAmmo3 = value; if (Ammo3Changed != null) Ammo3Changed(_currentAmmo3);
        if (_currentAmmo3 == 0)
        {
            NextWeapon();
        }
        }
    }

	public enum HeroWeapons
	{
		Dubinka,
        Butulka1,
        Butulka2,
        Butulka3
	}

    public enum FireDirection
    {
        Right,
        Left
    }

	public HeroWeapons HeroWeapon {
        get { return _heroWeapon; }
        private set { _heroWeapon = value; if (WeaponChanged != null) WeaponChanged(HeroWeapon); }
	}

    HeroWeapons _heroWeapon;

	public void NextWeapon()
	{
		switch (HeroWeapon)
		{
        case HeroWeapons.Dubinka: HeroWeapon = HeroWeapons.Butulka1; break;
        case HeroWeapons.Butulka1: HeroWeapon = HeroWeapons.Butulka2; break;
        case HeroWeapons.Butulka2: HeroWeapon = HeroWeapons.Butulka3; break;
        case HeroWeapons.Butulka3: HeroWeapon = HeroWeapons.Dubinka; break;
		}
		if(WeaponChanged != null) WeaponChanged(HeroWeapon);
	}

	void Start () {
        if (Instance != null) { Debug.LogError("Should be only one!"); }
        else Instance = this;
		GuiActions.NextWeapon += NextWeapon;
		KeyboardInput.NextWeapon += NextWeapon;
        HeroController.Fire += MainHeroFire;
        HeroController.Fire1 += MainHeroFireBut;
        HeroController.Fire2 += MainHeroFireBut;
        HeroController.Fire3 += MainHeroFireBut;
        HeroController.AddButulkaToWeapon = AddButulka;
        CurrentAmmo = StartAmmo;
        _currentAmmo1 = StartAmmobut1;
        _currentAmmo2 = StartAmmobut2;
        _currentAmmo3 = StartAmmobut3;
	}

    void OnDestroy()
    {
        Instance = null;
    }

    void AddButulka(int count, int type)
    {
        var audio = GetComponent<AudioSource>();

        audio.clip = clip;
        audio.Play();
        switch (type)
        {
            case 1:
                {
                    CurrentAmmo1 += count;
                    break;
                }
            case 2:
                {
                    CurrentAmmo2 += count;
                    break;
                }
            case 3:
                {
                    CurrentAmmo3 += count;
                    break;
                }
        }
        
    }

    void MainHeroFire(Vector2 firePoint, FireDirection direction)
    {
        if (CurrentAmmo <= 0) return;

        var d = Vector2.right;
        switch (direction)
        {
            case FireDirection.Left: d = new Vector2(-1, 0); break;
            case FireDirection.Right: d = Vector2.right; break;
        }

        if (Fire != null) Fire(firePoint, d);
        CurrentAmmo--;
    }

    void MainHeroFireBut(Vector2 firePoint, FireDirection direction, int type)
    {
        switch(type)
        {
            case 1:
                {
                    if (CurrentAmmo1 <= 0) { NextWeapon();  return; }

                    var d = Vector2.right;
                    switch (direction)
                    {
                        case FireDirection.Left: d = new Vector2(-1, 0); break;
                        case FireDirection.Right: d = Vector2.right; break;
                    }

                    if (Fire1 != null) Fire1(firePoint, d);
                    CurrentAmmo1--;
                    break;
                }
            case 2:
                {
                    if (CurrentAmmo2 <= 0) { NextWeapon(); return; }

                    var d = Vector2.right;
                    switch (direction)
                    {
                        case FireDirection.Left: d = new Vector2(-1, 0); break;
                        case FireDirection.Right: d = Vector2.right; break;
                    }

                    if (Fire2 != null) Fire2(firePoint, d);
                    CurrentAmmo2--;
                    break;
                }
            case 3:
                {
                    if (CurrentAmmo3 <= 0) { NextWeapon(); return; }

                    var d = Vector2.right;
                    switch (direction)
                    {
                        case FireDirection.Left: d = new Vector2(-1, 0); break;
                        case FireDirection.Right: d = Vector2.right; break;
                    }

                    if (Fire3 != null) Fire3(firePoint, d);
                    CurrentAmmo3--;
                    break;
                }
        }
    }
}
