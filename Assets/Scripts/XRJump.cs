using UnityEngine;
using UnityEngine.InputSystem;

public class XRJump : MonoBehaviour
{
    public CharacterController characterController;
    public InputActionReference jumpAction;
    public float jumpForce = 5f;
    private bool isGrounded;
    private Vector3 velocity;
    public float gravity = -9.81f; // Gravity simulation

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (jumpAction != null)
        {
            jumpAction.action.performed += ctx => Jump();
        }
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset falling velocity
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Jump formula
        }
    }
}
