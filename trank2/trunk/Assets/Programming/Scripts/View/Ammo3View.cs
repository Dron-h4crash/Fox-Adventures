using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo3View : MonoBehaviour
{

    void Awake()
    {
        WeaponManager.Ammo3Changed = (ammo) => gameObject.GetComponent<Text>().text = string.Format("X {0:D}", ammo);
    }
}