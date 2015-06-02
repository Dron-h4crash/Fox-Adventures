using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour
{
    #region Inspector
    public int StartHp = 100;
    public int KillPoint =50;
    #endregion

    int _hp;


    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    void Start()
    {
        Hp = StartHp;
        SendMessage("HpChangedMessage", Hp);
    }

    public void ApplyDamage(int damage)
    {
        Hp -= damage;
        if (Hp > 1000) Hp = 1000;
        if (Hp < 0f) 
        { 
            Hp = 0;
            var score = PlayerPrefs.GetInt("CurrentScore");
            score += KillPoint;
            PlayerPrefs.SetInt("CurrentScore", score);
            gameObject.SendMessage("Die");
            gameObject.SendMessage("RealyDie");
        }
        gameObject.SendMessage("HpChangedMessage", Hp);
        if (damage>0)
        gameObject.SendMessage("DamageReceived");
    }
}
