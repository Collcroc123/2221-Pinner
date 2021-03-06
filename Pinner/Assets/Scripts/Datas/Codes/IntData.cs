﻿using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}