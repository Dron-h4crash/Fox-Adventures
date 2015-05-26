using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HeroController : MonoBehaviour
{
    public AudioClip shag;
    public AudioClip prizem;
    public AudioClip dubinka;
    public AudioClip uron;

    public float[] Yspeed;

    public float MaxSpeed = 5f;
    public float JumpSpeed = 250f;
    public Transform GroundCheck;
    public LayerMask GroundLayerMask;

    public static Action<Vector2, WeaponManager.FireDirection> Fire;
    public static Action<Vector2, WeaponManager.FireDirection, int> Fire1;
    public static Action<Vector2, WeaponManager.FireDirection, int> Fire2;
    public static Action<Vector2, WeaponManager.FireDirection, int> Fire3;
    //    public static Action Hit;
    public static Action<float> HpChanged;

    public static Action<int, int> AddButulkaToWeapon;

    public static HeroController Instance;

    private float _moveX;
    private float _positionY = 1.0f; // от 0 до 1, 0 - лежит, 1 - стоит
    private Animator _anim;
    private const float GroundRadius = 0.12f;
    private bool _isFacingRight = true;

    public GameObject DubinkaHitting;
    public Transform HeroBulletSpawn;

    AudioSource audio;
    DubinkaManager dubinkaObject;

    public bool IsGrounded
    {
        get { if (GroundCheck != null) return Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayerMask); else return false; }
    }

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        _anim = GetComponent<Animator>();

        VirtualJoystick.Right += MoveRight;
        VirtualJoystick.Left += MoveLeft;
        VirtualJoystick.Stop += Stop;
        VirtualJoystick.Down += Down;
        GuiActions.Jump += Jump;
        GuiActions.Attack += Attack;
        GuiActions.Left += MoveLeft;
        GuiActions.Right += MoveRight;
        GuiActions.Stop += Stop;

        KeyboardInput.Left += MoveLeft;
        KeyboardInput.Right += MoveRight;
        KeyboardInput.Stop += Stop;
        KeyboardInput.Down += Down;
        KeyboardInput.Jump += Jump;
        KeyboardInput.Attack += Attack;

        WeaponManager.WeaponChanged += WeaponChanged;
        _anim.CrossFade("lis_stand_dubinka", 0f);

        audio = GetComponent<AudioSource>();
        dubinkaObject = GetComponent<DubinkaManager>();
    }

    void WeaponChanged(WeaponManager.HeroWeapons weapon)
    {
        if (_anim != null)
        {
            switch (weapon)
            {
                case WeaponManager.HeroWeapons.Dubinka:
                    _anim.CrossFade("lis_stand_dubinka", 0f);
                    break;
                case WeaponManager.HeroWeapons.Butulka1:
                    _anim.CrossFade("lis_stand_with_butulka", 0f);
                    break;
                case WeaponManager.HeroWeapons.Butulka2:
                    _anim.CrossFade("lis_stand_with_butulka", 0f);
                    break;
                case WeaponManager.HeroWeapons.Butulka3:
                    _anim.CrossFade("lis_stand_with_butulka", 0f);
                    break;
            }
        }
    }

    void Down()
    {
        StartCoroutine(GoDown());
    }

    IEnumerator GoDown()
    {
        if (_anim != null)
        {
            _positionY = 0.5f;
            _anim.SetFloat("yPos", _positionY);
            yield return new WaitForEndOfFrame();
            _positionY = 0.0f;
            _anim.SetFloat("yPos", _positionY);
        }
    }
    IEnumerator GoUp()
    {
        if (_anim != null)
        {
            _positionY = 0.5f;
            _anim.SetFloat("yPos", _positionY);
            yield return new WaitForEndOfFrame();
            _positionY = 1.0f;
            _anim.SetFloat("yPos", _positionY);
        }
    }

    void MoveRight()
    {
        if (_positionY < 1.0f) return;
        _moveX = 1f;
    }

    void MoveLeft()
    {
        if (_positionY < 1.0f) return;
        _moveX = -1f;
    }

    void Stop()
    {
        if (_positionY < 1.0f) StartCoroutine(GoUp());
        if (IsGrounded)
            _moveX = 0f;
        // если герой в прыжке, подождать останавливать до приземления
    }


    public void Jump()
    {
        if (_positionY < 1f) return;

        if (IsGrounded) rigidbody2D.AddForce(new Vector2(0, JumpSpeed));

        //if (IsGrounded)
        //{
        //    StartCoroutine(JumpAnimation());
        //}
    }

    //IEnumerator JumpAnimation()
    //{
    //    //		for (var i = 0; i < 3; i++) yield return new WaitForFixedUpdate();
    //    Debug.LogError("Start!");
    //    string[] seconds = new string[30];
    //    var start = DateTime.Now;

    //    for (var i = 0; i < 30; i++)
    //    {
    //       // rigidbody2D.AddForce(new Vector2(0, JumpSpeed));
    //       // yield return new WaitForFixedUpdate();
    //        Yspeed[i] = rigidbody2D.velocity.y;
    //        seconds[i] = string.Format("i: {0}, ms: {1}",i,(DateTime.Now - start).TotalMilliseconds);
    //        yield return new WaitForSeconds(1f/32f);
    //    }
    //    for (var j = 0; j < 30; j++) Debug.Log(seconds[j]);
    //        Debug.LogError("Stop!");
    //    Debug.Log((DateTime.Now - start).TotalMilliseconds);
    //}

    void Attack(bool on)
    {
        if (!on)
        {
            if (_anim != null) _anim.SetBool("Attack", on);
            return;
        }
        WeaponAnimate();

    }

    protected void WeaponAnimate()
    {
        if (_anim != null) _anim.SetBool("Attack", true);
        //	if (IsGrounded)  yield return new WaitForSeconds(0.3f);

        if (WeaponManager.Instance.HeroWeapon == WeaponManager.HeroWeapons.Dubinka)
        {
            //	if (dubinkaObject != null) dubinkaObject.DubinkaHit();      
            BroadcastMessage("DubinkaHit");
            if (audio != null)
            {
                audio.clip = dubinka;
                audio.Play();

            }
        }
        else if (WeaponManager.Instance.HeroWeapon == WeaponManager.HeroWeapons.Butulka1)
        {
            if (Fire1 != null && HeroBulletSpawn != null && _isFacingRight != null)
                Fire1(HeroBulletSpawn.position, _isFacingRight ? WeaponManager.FireDirection.Right : WeaponManager.FireDirection.Left, 1);
        }
        else if (WeaponManager.Instance.HeroWeapon == WeaponManager.HeroWeapons.Butulka2)
        {
            if (Fire2 != null && HeroBulletSpawn != null)
                Fire2(HeroBulletSpawn.position, _isFacingRight ? WeaponManager.FireDirection.Right : WeaponManager.FireDirection.Left, 2);
        }
        else if (WeaponManager.Instance.HeroWeapon == WeaponManager.HeroWeapons.Butulka3)
        {
            if (Fire3 != null && HeroBulletSpawn != null)
                Fire3(HeroBulletSpawn.position, _isFacingRight ? WeaponManager.FireDirection.Right : WeaponManager.FireDirection.Left, 3);
        }
    }

    bool play = false;

    private void FixedUpdate()
    {


        var speedX = _moveX;
        //        var speedY = 0f;
        var speedY = rigidbody2D.velocity.y;

        _anim.SetBool("Ground", IsGrounded);
        _anim.SetFloat("Speed", Mathf.Abs(_moveX));
        _anim.SetFloat("ySpeed", speedY);

        rigidbody2D.velocity = new Vector2(speedX * MaxSpeed, speedY);
        if (speedX > 0f && !_isFacingRight || speedX < 0f && _isFacingRight) Flip();


        if (IsGrounded && speedY == 0 && Mathf.Abs(_moveX) != 0)
        {
            if (!play)
            {
                StartCoroutine(shagsound());
                play = true;
            }

        }
    }

    protected IEnumerator shagsound()
    {
        if (audio != null)
        {
            audio.clip = shag;
            audio.Play();
        }
        yield return new WaitForSeconds(0.2f);
        play = false;
    }


    private void Update()
    {
  //      if (Input.GetKeyUp(KeyCode.Space))
  //      {
           // yield return new WaitForSeconds(0.5f);
    //        LoadingConfig.Scene = Application.loadedLevel + 1;
    //        Application.LoadLevel(7);
    //    }   ТЕСТЫ
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Die()
    {
        StartCoroutine(DieAnimate());
    }

    protected IEnumerator DieAnimate()
    {

        _anim.SetBool("Die", true);
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel("Game Over");


    }

    public void HpChangedMessage(float hp)
    {
        if (HpChanged != null) HpChanged(hp);
        //if (hp == 0)
        //{
        //	_anim.SetBool("Die", true);
        //	Application.LoadLevel("Game Over");
        //}
    }

    public void DamageReceived()
    {
        StartCoroutine(DamageAnimate());

        if (audio != null)
        {
            audio.clip = uron;
            audio.Play();
        }
    }

    protected IEnumerator DamageAnimate()
    {
        _anim.SetTrigger("Damage");
        //отодвинуть назад
        if (_isFacingRight)
        {
            if (IsGrounded) rigidbody2D.AddForce(new Vector2(-850f, 0f));
        }
        else
        {
            if (IsGrounded) rigidbody2D.AddForce(new Vector2(850f, 0));
        }
        yield return new WaitForSeconds(0.1f);


    }

    public void AddButulka1(int count)
    {
        AddButulkaToWeapon(count, 1);
    }
    public void AddButulka2(int count)
    {
        AddButulkaToWeapon(count, 2);
    }
    public void AddButulka3(int count)
    {
        AddButulkaToWeapon(count, 3);
    }

    private bool moveKonv = false;

    public void KoveyerMove(bool left)
    {
        //Debug.Log("123");
        if (!moveKonv)
            MoveKonveier(left);

    }
    protected void MoveKonveier(bool left)
    {
        moveKonv = true;
        if (left)
        {
            rigidbody2D.AddForce(new Vector2(-300f, 80f));

        }
        else
        {
            rigidbody2D.AddForce(new Vector2(300f, 80f));

        }
        //yield return new WaitForSeconds(0.1f);
        moveKonv = false;
    }
}
