
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        GroundCheck();
        HandleJump();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void GroundCheck()
    {
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            1.1f,
            groundLayer
        );
    }

    void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Vector3 velocity = move.normalized * moveSpeed;

        velocity.y = rb.linearVelocity.y;

        rb.linearVelocity = velocity;
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
