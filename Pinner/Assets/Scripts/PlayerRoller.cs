using UnityEngine;

public class PlayerRoller : MonoBehaviour
{
    private Rigidbody ball;
    private Vector3 movement;
    private float currentSpeed = 5f;
    private float maxSpeed = 30f;
    private float gravity = 0f;
    private float jumpForce = 5f;
    private bool grounded;
    public bool speedLimit = true;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.z = Input.GetAxis("Vertical") * currentSpeed;
        movement.x = Input.GetAxis("Horizontal") * currentSpeed;
        
        if (gravity > -1f)
        {
            gravity += -0.01f;
            //gravity = -1f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            gravity = 0f;
            gravity += jumpForce;
        }
        movement.y = gravity;
        ball.AddForce(movement);
        if (ball.velocity.magnitude > 40f)
        {
            if (speedLimit)
            {
                ball.velocity = ball.velocity.normalized * maxSpeed;
            }
        }
    }
}