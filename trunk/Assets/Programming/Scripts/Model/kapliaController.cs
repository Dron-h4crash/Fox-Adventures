using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class kapliaController : MonoBehaviour {

    private bool inFly = false;
    protected Animator _anim;
    public static Action<Vector2> Fire;
    public Transform kapliaStart;

	void Start () {
        _anim = GetComponent<Animator>();
        if (!inFly)
            Attack();
	}

    void Attack()
    {
        inFly = true;
        StartCoroutine(kapliaBrosok());
    }

    protected IEnumerator kapliaBrosok()
    {
        _anim.SetBool("fire", true);
        //rigidbody2D.velocity = new Vector2(MainHero.transform.position.x > transform.position.x ? SpeedX : -SpeedX, 0);
        yield return new WaitForSeconds(0.1f);
        _anim.SetBool("fire", false);
        Fire(kapliaStart.position);
        yield return new WaitForSeconds(3f);
        StopAttack();
    }

    void StopAttack()
    {
        Debug.Log("stop");
        inFly = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!inFly)
            Attack();
	}
}
