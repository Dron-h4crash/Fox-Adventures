using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoView : MonoBehaviour
{
    void Awake()
    {
        WeaponManager.AmmoChanged += (ammo) => gameObject.GetComponent<Text>().text = string.Format("Ammo: {0:D}", ammo);
    }
}
