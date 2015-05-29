using UnityEngine;
using System.Collections;

public class DubinkaManager : MonoBehaviour
{
    public int FramesPassCount = 4;
    public int FramesHitCount = 8;

    bool _hitOn;

    void Start()
    {
//        HeroController.Hit += Hit;
        collider2D.enabled = false;
    }

    public void DubinkaHit()
    {
        StartCoroutine(WaitAndDisable());
    }

    IEnumerator WaitAndDisable()
    {
        if(_hitOn) yield break;
        _hitOn = true;
        for (var i = 0; i < FramesPassCount; i++) yield return new WaitForFixedUpdate();
        collider2D.enabled = true;
        for (var i = 0; i < FramesHitCount; i++) yield return new WaitForFixedUpdate();
        collider2D.enabled = false;
        _hitOn = false;
    }
}
