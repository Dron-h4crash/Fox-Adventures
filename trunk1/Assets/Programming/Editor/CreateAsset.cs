using UnityEngine;
using System.Collections;

using UnityEditor;

public class CreateAsset
{
    [MenuItem("Assets/Create/ScriptableObject")]
    public static void CreateAnAsset()
    {
        Icons asset = ScriptableObject.CreateInstance<Icons>();
//        Icons.IconsDB = asset;

        AssetDatabase.CreateAsset(asset, "Assets/NewScriptableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}

