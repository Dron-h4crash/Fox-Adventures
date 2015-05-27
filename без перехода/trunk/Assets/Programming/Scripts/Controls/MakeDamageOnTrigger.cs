using UnityEngine;
using System.Collections;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int Damage;
    public string EnemyTag;
    // Use this for initialization
    void Start()
    {
        if (string.IsNullOrEmpty(EnemyTag)) Debug.LogError("No Enemy Tag Set!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(string.Format("Hit: {0}", other.gameObject.name));
        if(other.gameObject.tag == EnemyTag) other.gameObject.SendMessageUpwards("ApplyDamage", Damage);
    }
}
