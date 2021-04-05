using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Character Controller using Input System and Cinemachine
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class RealPlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Input action Vector2 movement")]
    private InputActionReference movementControl = null;

    [SerializeField, Tooltip("Input action for button/float jump")]
    private InputActionReference jumpControl = null;

    [SerializeField, Tooltip("Input action for button run")]
    private InputActionReference runControl = null;

    [SerializeField, Tooltip("Speed multiplier")]
    private float playerSpeed = 5.0f;

    [SerializeField, Tooltip("Run speed multiplier")]
    private float sprintSpeed = 10.0f;

    [SerializeField, Tooltip("How high can the player jump")]
    private float jumpHeight = 2.0f;

    [SerializeField, Tooltip("Rotation speed multiplier")]
    private float wallJumpForce = 4f;

    [SerializeField, Tooltip("Camera")]
    private Transform cameraMainTransform;

    [SerializeField, Tooltip("additionalGravity")]
    private Vector3 additionalGravity;

    //[SerializeField, Tooltip("isGrounded")]
    private bool isGrounded;
    private float DistanceToTheGround;

    private Vector3 moveVector;
    private Vector2 movement;

    private Rigidbody rb;
    private Vector3 lastContact;
   
    private bool doubleJump = false;
    private bool isRunning = false;

    #region setup
    private void OnEnable() {
        if (movementControl != null) movementControl.action.Enable();
        if (jumpControl != null) jumpControl.action.Enable();
        if (runControl != null) runControl.action.Enable();
    }

    private void OnDisable() {
        if (movementControl != null) movementControl.action.Disable();
        if (jumpControl != null) jumpControl.action.Disable();
        if (runControl != null) runControl.action.Disable();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    #endregion setup
    void Update()
    {
        DistanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, DistanceToTheGround + 0.2f);

        movement = movementControl.action.ReadValue<Vector2>();
        moveVector = new Vector3(movement.x, 0f, movement.y);
        moveVector = cameraMainTransform.forward * moveVector.z + cameraMainTransform.right * moveVector.x;
        moveVector.y = 0f;
        if (moveVector != Vector3.zero){
            transform.forward = moveVector;
        }


        if (jumpControl.action.triggered && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.Impulse);
        }

    }

    void FixedUpdate(){
        /*
        if (jumpControl.action.triggered && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Acceleration);
        }
        */
        if (!isGrounded)
        {
            rb.AddForce(additionalGravity, ForceMode.Acceleration);
        }
        Vector3 velocity = moveVector * playerSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
    
    private void OnCollisionStay (Collision collision){
         ContactPoint contact = collision.GetContact(0);
        if (!isGrounded && contact.normal.y < 0.1f)
        {
            if (jumpControl.action.triggered)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.yellow, 40f);
                lastContact = Vector3.up + contact.normal;
                lastContact.x *= wallJumpForce;
                lastContact.y *= Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                lastContact.z *= wallJumpForce;
                rb.AddForce(lastContact, ForceMode.VelocityChange);
                transform.forward = contact.normal;
                Debug.DrawRay(contact.point, Vector3.up.normalized, Color.red, 40f);
                Debug.DrawRay(contact.point, lastContact.normalized, Color.blue, 40f);
            }
        }
    }
    
}