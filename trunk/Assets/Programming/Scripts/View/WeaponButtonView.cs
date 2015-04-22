using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponButtonView : MonoBehaviour {
    Image WeaponButton;
    public Icons IconsDB;

	void Awake () {
        WeaponButton = gameObject.GetComponent<Image>();
        WeaponManager.WeaponChanged += ShowWeaponIcon;
	}

    void ShowWeaponIcon(WeaponManager.HeroWeapons weapon)
    {
        switch (weapon)
        {
            case WeaponManager.HeroWeapons.Dubinka: WeaponButton.sprite = IconsDB.GetIcon("Dubinka"); break;
            case WeaponManager.HeroWeapons.Butulka1: WeaponButton.sprite = IconsDB.GetIcon("Butulka1"); break;
            case WeaponManager.HeroWeapons.Butulka2: WeaponButton.sprite = IconsDB.GetIcon("Butulka2"); break;
            case WeaponManager.HeroWeapons.Butulka3: WeaponButton.sprite = IconsDB.GetIcon("Butulka3"); break;
        }
    }
}
