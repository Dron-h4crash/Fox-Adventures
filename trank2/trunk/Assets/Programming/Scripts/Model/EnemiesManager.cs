using UnityEngine;
using System.Collections;

public class EnemiesManager : MonoBehaviour {

    VoronaController[] VoronaControllers;
	
	void Start () {
        var Voronas = GameObject.FindGameObjectsWithTag("Enemy");
        if (Voronas != null)
        {
            VoronaControllers = new  VoronaController[Voronas.Length];
            for (var i = 0; i < Voronas.Length; i++)
                VoronaControllers[i] = Voronas[i].GetComponent<VoronaController>();
        }
	}
	
	void Update () {
	
	}
}
