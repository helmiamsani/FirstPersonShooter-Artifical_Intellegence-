using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 10f;
    public float walkSpeed = 6f;
    public float gravity = -30f;
    public float jumpHeight = 10f;
    public float groundRayDistance = 1.1f;
    private CharacterController controller; // Reference to character controller
    private Vector3 motion; // Is the movement offset per frame
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // W A S D / Right Left Up Down Arrow Input
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Left Shift Input
        bool inputRun = Input.GetKey(KeyCode.LeftShift);
        // Space Bar Input
        bool inputJump = Input.GetButton("Jump");

        // Put Horizontal & Vertical input into vector
        Vector3 inputDir = new Vector3(inputH, 0f, inputV);
        // Rotate direction to Player's Direction
        inputDir = transform.TransformDirection(inputDir);
        // If input exceeds length of 1
        if(inputDir.magnitude > 1)
        {
            // Normalize it to 1f!
            inputDir.Normalize();
        }        

        if (inputRun)
        {
            Run(inputDir.x, inputDir.z);
        }
        else
        {
            Walk(inputDir.x, inputDir.z);
        }

        // If player is on the ground AND pressed "Jump"
        if (IsGrounded() && inputJump)
        {
            Jump();
        }

        // If is NOT Grounded AND isJumping
        if(!IsGrounded() && isJumping)
        {
            // Set isJumping to false
            isJumping = false;
        }

        motion.y += gravity * Time.deltaTime;

        controller.Move(motion * Time.deltaTime);
    }

    bool IsGrounded()
    {
        // Raycast below the Player
        Ray groundRay = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        // If hitting something
        if (Physics.Raycast(groundRay, out hit, groundRayDistance))
        {
            return true;
        }
        return false;
    }

    void Move(float inputH, float inputV, float speed)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);

        // Convert local direction to world space direction (relative to Player's transform) 
        // direction = transform.TransformDirection(direction);

        motion.x = direction.x * speed;
        motion.z = direction.z * speed;
    }

    public void Walk(float inputH, float inputV)
    {
        Move(inputH, inputV, walkSpeed);
    }

    public void Run(float inputH, float inputV)
    {
        Move(inputH, inputV, runSpeed);
    }

    public void Jump()
    {
        motion.y = jumpHeight;
        isJumping = true;
    }

}
