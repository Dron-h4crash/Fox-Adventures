using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GroundManager))]
public class RecalculateGround : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GroundManager myScript = (GroundManager)target;
        if (GUILayout.Button("пересчитать землю"))
        {
            myScript.RecalculateGround();
        }
    }
}
