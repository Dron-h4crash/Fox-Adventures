using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DuremarController : EnemyController
{

    #region Inspector
    public GameObject LeftLimit;
    public GameObject RightLimit;
    public GameObject MainHero;
    public float SameLevelDistance;
    public float CloseToAttack;
    public List<string> TurnTags;
    public int nextLevel;
    #endregion

    public static Action<Vector2, Vector2> Fire;
    public Transform HeroBulletSpawn;
    bool _attack;
    private float _moveX;

    protected override IEnumerator Moving()
    {
        while (Application.isPlaying)
        {
            if (!_attack)
            {
                rigidbody2D.velocity = new Vector2(UnityEngine.Random.Range(-1, 2) * SpeedX, 0f);
                yield return new WaitForSeconds(UnityEngine.Random.Range(0, 3f));
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0f, 0f);
                yield return new WaitForEndOfFrame();

            }
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
        if (!_attack)
        {
            if (Mathf.Abs(transform.position.x - MainHero.transform.position.x) < 5 && (Mathf.Abs(transform.position.y - MainHero.transform.position.y) < 0.3))
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
        if (MainHero.transform.position.x < transform.position.x && _isFacingRight)
        {
            Flip();
        }
		if (MainHero.transform.position.x > transform.position.x && !_isFacingRight)
		{
			Flip();
		}
        StartCoroutine(ButulkaBrosok());
        //Fire(HeroBulletSpawn.position, rigidbody2D.velocity.x>0) ? WeaponManager.FireDirection.Right : WeaponManager.FireDirection.Left);


    }


    protected IEnumerator ButulkaBrosok()
    {
        _anim.SetBool("Attack", true);
        //rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
        yield return new WaitForSeconds(0.3f);
        _anim.SetBool("Attack", false);
        Fire(HeroBulletSpawn.position, _isFacingRight ? Vector2.right : new Vector2(-1, 0));
        yield return new WaitForSeconds(2f);
        StopAttack();
    }

    void StopAttack()
    {
        _attack = false;
        _anim.SetBool("Attack", false);
    }

    public void RealyDie()
    {
        StartCoroutine(DieAnimate2());
    }
    protected IEnumerator DieAnimate2()
    {

        yield return new WaitForSeconds(0.5f);
        Fire = null;
        Application.LoadLevel(nextLevel);
    }
}
