using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpView : MonoBehaviour
{
    Image HpImage;
    public Icons IconsDB;

    void Awake()
    {
        HpImage = gameObject.GetComponent<Image>();
        HeroController.HpChanged += ShowHPIcon;
    }

    void ShowHPIcon(float  hp)
    {
        if (hp>999)
            HpImage.sprite = IconsDB.GetIcon("hp1");
        else if (hp > 900)
            HpImage.sprite = IconsDB.GetIcon("hp2");
        else if (hp > 800)
            HpImage.sprite = IconsDB.GetIcon("hp3");
        else if (hp > 700)
            HpImage.sprite = IconsDB.GetIcon("hp4");
        else if (hp > 600)
            HpImage.sprite = IconsDB.GetIcon("hp5");
        else if (hp > 500)
            HpImage.sprite = IconsDB.GetIcon("hp6");
        else if (hp > 400)
            HpImage.sprite = IconsDB.GetIcon("hp7");
        else if (hp > 300)
            HpImage.sprite = IconsDB.GetIcon("hp8");
        else if (hp > 200)
            HpImage.sprite = IconsDB.GetIcon("hp9");
        else if (hp > 100)
            HpImage.sprite = IconsDB.GetIcon("hp10");
        else if (hp <= 100)
            HpImage.sprite = IconsDB.GetIcon("hp11");
        if (hp <= 0)
        {
            HpImage.sprite = IconsDB.GetIcon("hp11");
        }
    }
}
