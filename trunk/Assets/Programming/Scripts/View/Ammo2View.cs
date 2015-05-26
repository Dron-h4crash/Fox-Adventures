using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo2View : MonoBehaviour
{

    void Awake()
    {
		if (WeaponManager.Ammo2Changed != null)
        WeaponManager.Ammo2Changed += (ammo) => gameObject.GetComponent<Text>().text = string.Format("X {0:D}", ammo);
    }
}