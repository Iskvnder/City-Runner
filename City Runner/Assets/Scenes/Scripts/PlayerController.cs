using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f; // movement speed of the player

    private float horizontalInput; // input from horizontal axis
    private Rigidbody playerRb; // rigidbody of the player

    private void Start()
    {
        // get the rigidbody component
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // get input from horizontal axis
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        // move the player left or right based on the horizontal input
        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0f, 0f);
        playerRb.MovePosition(transform.position + movement);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
