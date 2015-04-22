using UnityEngine;
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
                if (_anim.GetCurrentAnimationClipState(0).Length > 0)
                    yield return new WaitForSeconds(CircleLength * _anim.GetCurrentAnimationClipState(0)[0].clip.length);
                else yield return new WaitForSeconds(19f/30f); // длина анимации взмаха крыла 19 кадров, 30 кадров в секунду
                rigidbody2D.AddForce(Vector2.up * WingsForce);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
