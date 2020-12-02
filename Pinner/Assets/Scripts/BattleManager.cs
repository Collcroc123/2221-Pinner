using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private float rotateSpeed = 90f;
    private bool enterRotation = false;

    void Update()
    {
        if (!enterRotation)
        {
            RotatePlayer();
        }
    }

    void RotatePlayer()
    {
        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
        transform.Rotate(0,-hInput,0);
        if (Input.GetButtonDown("Jump"))
        {
            enterRotation = true;
        }
    }
}
