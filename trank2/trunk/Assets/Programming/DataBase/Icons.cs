using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Icons : ScriptableObject {
    public DictionaryOfStringAndSprite IconsDictionary;

    public Sprite GetIcon(string key)
    {
        return IconsDictionary.ContainsKey(key)? IconsDictionary[key] : null;
    }
}