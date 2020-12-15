using UnityEngine;

[CreateAssetMenu]
public class ObjectData : ScriptableObject
{
    public GameObject value;
    
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}