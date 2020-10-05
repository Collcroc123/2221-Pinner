using UnityEngine;

public class Jump : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;
    public float moveSpeed = 7.5f;
    public int jumpHeight = 3;
    private int jumpCount = 1;

    void Update()
    {
        /*//MOVEMENT
        var horiAxis = Input.GetAxis("Horizontal");
        var vertAxis = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horiAxis, 0,vertAxis);
        controller.Move(move * (Time.deltaTime * moveSpeed));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 7.5f;
        }
        */
        
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            velocity.y = jumpHeight;
            jumpCount++;
        }
        if (controller.isGrounded)
        {
            jumpCount = 1;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}