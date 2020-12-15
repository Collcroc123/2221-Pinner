using UnityEngine;

public class SetSpawn : MonoBehaviour
{
    public Vector3Data spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        spawnPoint.value = transform.position;
    }
}