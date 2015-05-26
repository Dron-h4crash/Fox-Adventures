using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour
{
    #region Inspector
    public int StartHp = 100;
    public int KillPoint =50;
    #endregion

    public int _hp;


    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public void SetStartHP()
    {
        Hp = StartHp;
        SendMessage("HpChangedMessage", Hp);
    }

    void Start()
    {
        SetStartHP();  
    }

    public void ApplyDamage(int damage)
    {
        Hp -= damage;
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
        gameObject.SendMessage("DamageReceived");
    }
}
