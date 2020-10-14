using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvents : MonoBehaviour
{
    private MeshRenderer mesh;
    public Color defaultColor = Color.red;
    public Color enterColor = Color.blue;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        mesh.material.color = enterColor;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        mesh.material.color = defaultColor;
    }
}
