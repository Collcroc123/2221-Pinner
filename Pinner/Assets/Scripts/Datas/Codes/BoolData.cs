using UnityEngine;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool value = false;
    
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}