using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KrolikController : EnemyController
{
    #region Inspector
    public GameObject LeftLimit;
    public GameObject RightLimit;
    public GameObject MainHero;
    public float SameLevelDistance;
    public float CloseToAttack;
    public List<string> TurnTags;
    #endregion

    bool _attack;

    protected override IEnumerator Moving()
    {
        while(Application.isPlaying)
        {
            if (!_attack)
            {
                rigidbody2D.velocity = new Vector2(Random.Range(-1, 2) * SpeedX, 0f);
                yield return new WaitForSeconds(Random.Range(0, 3f));
            }
            else yield return new WaitForEndOfFrame();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (TurnTags.Contains(coll.gameObject.tag)) rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x, 0f);
       // rigidbody2D.velocity = coll.contacts[0].normal; // сменить скорость на противоположную точке соприкосновения
    }

    protected override void FixedUpdate()
    {
        if (CloseToHero() && !_attack) Attack();
        
        if (transform.position.x < LeftLimit.transform.position.x) rigidbody2D.velocity = new Vector2(SpeedX, 0f);
        if (transform.position.x > RightLimit.transform.position.x) rigidbody2D.velocity = new Vector2(-SpeedX, 0f);
		if(!_attack)
		{
        if (Mathf.Abs(transform.position.x - MainHero.transform.position.x) < 2 && (Mathf.Abs(transform.position.y - MainHero.transform.position.y) < 0.3))
        {
            rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
        }
		}
        base.FixedUpdate();
        _anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
    }
    bool CloseToHero()
    {
        return (Mathf.Abs(transform.position.y - MainHero.transform.position.y) < SameLevelDistance) && (Mathf.Abs(transform.position.x - MainHero.transform.position.x) < CloseToAttack);
    }
    void Attack()
    {
        _attack = true;
        StartCoroutine(DubinkaUdar());
        //rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
        //_anim.SetBool("Attack", true);
    }

    protected IEnumerator DubinkaUdar()
    {
        _anim.SetBool("Attack", true);
        //rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
		rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.33f);
        BroadcastMessage("DubinkaHit");
        StopAttack();
    }

    void StopAttack()
    {
        _attack = false;
        _anim.SetBool("Attack", false);
    }
}
