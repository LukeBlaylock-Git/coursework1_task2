using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 4f;
    private Vector2 moveInput;
    [SerializeField] bool isGrounded = false;

    [SerializeField] Transform Respawn;
    private Rigidbody rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
            RespawnPlayer();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x * movementSpeed, 0f, moveInput.y * movementSpeed) *Time.fixedDeltaTime;
        Vector3 currentPos = rb.position;
        rb.MovePosition(currentPos + movement);
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        {
            if (context.performed && isGrounded == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    public void RespawnPlayer()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = Respawn.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
