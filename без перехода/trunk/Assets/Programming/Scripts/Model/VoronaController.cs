﻿using UnityEngine;
using System.Collections;

public class VoronaController : EnemyController
{
    public float WingsForce = 15f;
    public float CircleLength = 1f;

    protected override IEnumerator Moving()
    {
        while (Application.isPlaying)
        {
            if (_health.Hp > 0)
            {
               // rigidbody2D.AddForce(Vector2.up * WingsForce);
                rigidbody2D.velocity = new Vector2(getDirection() * SpeedX, 0f);
                yield return new WaitForSeconds(19f/30f); // длина анимации взмаха крыла 19 кадров, 30 кадров в секунду
                //rigidbody2D.AddForce(Vector2.up * WingsForce);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private int getDirection()
    {
        var data = Random.Range(-1, 2);
        while(data==0)
        {
            data = Random.Range(-1, 2);
        }

        return data;
    }

    public void RealyDie()
    {
        StartCoroutine(DieAnimateVor());
    }

    protected IEnumerator DieAnimateVor()
    {
        //rigidbody2D.isKinematic = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

	protected override void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Butulka")
		{
			Physics2D.IgnoreCollision(gameObject.collider2D, coll.gameObject.collider2D);
		}
		else
		{
			rigidbody2D.velocity = coll.contacts[0].normal;
		}
		//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x == 0 ? 0.5f : -rigidbody2D.velocity.x, -rigidbody2D.velocity.y);
	}
}
