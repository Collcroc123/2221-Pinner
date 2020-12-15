using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}