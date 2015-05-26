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
		if (WeaponButton != null) {
			if (weapon == WeaponManager.HeroWeapons.Dubinka && IconsDB.GetIcon ("Dubinka") != null)
				WeaponButton.sprite = IconsDB.GetIcon ("Dubinka");
			else if (weapon == WeaponManager.HeroWeapons.Butulka1 && IconsDB.GetIcon ("Butulka1") != null)
				WeaponButton.sprite = IconsDB.GetIcon ("Butulka1");
			else if (weapon == WeaponManager.HeroWeapons.Butulka2 && IconsDB.GetIcon ("Butulka2") != null)
				WeaponButton.sprite = IconsDB.GetIcon ("Butulka2");
			else if (weapon == WeaponManager.HeroWeapons.Butulka3 && IconsDB.GetIcon ("Butulka3") != null)
				WeaponButton.sprite = IconsDB.GetIcon ("Butulka3");
		}
    }
}
