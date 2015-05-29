using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    private float Current;
    private float WaitFor;

    IEnumerator Start()
    {
        var Objects = GameObject.FindGameObjectWithTag("MainHero");
        if (Objects != null)
            Objects.transform.position = new Vector3(0, -62, 0);
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(LoadingConfig.Scene);
    }

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
    }
}
