using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DictionaryOfStringAndSprite : SerializableDictionary<string, Sprite> { }


[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys;

    [SerializeField]
    private List<TValue> values;

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        //keys.Clear();
        //values.Clear();
        //foreach (KeyValuePair<TKey, TValue> pair in this)
        //{
        //    keys.Add(pair.Key);
        //    values.Add(pair.Value);
        //}
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        if (keys.Count != values.Count) return;
           // throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
        this.Clear();
        for (int i = 0; i < keys.Count; i++)
            this.Add(keys[i], values[i]);
    }
}