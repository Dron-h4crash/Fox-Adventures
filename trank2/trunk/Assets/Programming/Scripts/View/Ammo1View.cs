using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ammo1View : MonoBehaviour {

    void Awake()
    {
        WeaponManager.Ammo1Changed = (ammo) => gameObject.GetComponent<Text>().text = string.Format("X {0:D}", ammo);
    }

    void OnDestroy()
    {
        
    }
}
