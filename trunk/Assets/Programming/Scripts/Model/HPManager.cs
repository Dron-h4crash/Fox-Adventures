using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour
{
    #region Inspector
    public int StartHp = 100;
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
        if (Hp < 0f) 
        { 
            Hp = 0;
            gameObject.SendMessage("Die");
            gameObject.SendMessage("RealyDie");
        }
        gameObject.SendMessage("HpChangedMessage", Hp);
        gameObject.SendMessage("DamageReceived");
    }
}
