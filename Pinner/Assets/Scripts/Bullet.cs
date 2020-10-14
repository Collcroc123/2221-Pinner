using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rBody;
    public float force = 50f;
    public float lifeTime = 3f;
    
    private IEnumerator Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.AddRelativeForce(Vector3.forward * force);
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    
}
