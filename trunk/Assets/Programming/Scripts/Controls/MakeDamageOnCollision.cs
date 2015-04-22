using UnityEngine;
using System.Collections;

public class MakeDamageOnCollision : MonoBehaviour
{
    public float Damage;
    public string EnemyTag;
    // Use this for initialization
    void Start()
    {
        if (string.IsNullOrEmpty(EnemyTag)) Debug.LogError("No Enemy Tag Set!");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(string.Format("Hit: {0}", other.gameObject.name));
        if(other.gameObject.tag == EnemyTag) other.gameObject.SendMessageUpwards("ApplyDamage", Damage);
    }
}
