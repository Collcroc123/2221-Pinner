using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rigBod;
    public float speed = 20;
    
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float vertAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 50;
        }
        else
        {
            speed = 20;
        }
        
        Vector3 movement = new Vector3(horAxis, 0, vertAxis) * (speed * Time.deltaTime);
        
        rigBod.MovePosition(transform.position + movement);
    }
}
