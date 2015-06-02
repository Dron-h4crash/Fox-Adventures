using UnityEngine;
using System.Collections;

public class dp7cmPD6MC : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            DontDestroyOnLoad(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
