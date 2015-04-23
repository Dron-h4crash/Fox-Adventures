﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KolobokKontroller : EnemyController
{
	#region Inspector
	public GameObject LeftLimit;
	public GameObject RightLimit;
	public GameObject MainHero;
	public float SameLevelDistance;
	public float CloseToAttack;
	public List<string> TurnTags;
	#endregion

	//public static Action<Vector2, WeaponManager.FireDirection, int> Fire;

	bool _attack;

	protected override IEnumerator Moving()
	{
		while (Application.isPlaying)
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
		if (CloseToHero()) Attack();
		else if (_attack) StopAttack();
		if (transform.position.x < LeftLimit.transform.position.x) rigidbody2D.velocity = new Vector2(SpeedX, 0f);
		if (transform.position.x > RightLimit.transform.position.x) rigidbody2D.velocity = new Vector2(-SpeedX, 0f);
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
		rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
		_anim.SetBool("Attack", true);
	}
	void StopAttack()
	{
		_attack = false;
		_anim.SetBool("Attack", false);
	}
}