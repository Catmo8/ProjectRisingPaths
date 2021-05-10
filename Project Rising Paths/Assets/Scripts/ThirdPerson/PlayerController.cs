using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Character Controller using Input System and Cinemachine
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Input action Vector2 movement")]
    private InputActionReference movementControl = null;

    [SerializeField, Tooltip("Input action for button/float jump")]
    private InputActionReference jumpControl = null;

    [SerializeField, Tooltip("Input action for button run")]
    private InputActionReference runControl = null;

    [SerializeField, Tooltip("Input action for accessing menu")]
    private InputActionReference menuControl = null;

    [SerializeField, Tooltip("Speed multiplier")]
    private float playerSpeed = 5.0f;

    [SerializeField, Tooltip("Run speed multiplier")]
    private float sprintSpeed = 10.0f;

    [SerializeField, Tooltip("Turn speed multiplier")]
    private float smoothTurnSpeed = 0.1f;

    [SerializeField, Tooltip("Smooths out animation transitions")]
    private float animationSmoothing = 0.1f;

    [SerializeField, Tooltip("How high can the player jump")]
    private float jumpHeight = 2.0f;

    [SerializeField, Tooltip("Camera")]
    private Transform cameraMainTransform;

    [SerializeField, Tooltip("Adds additional gravity to player when falling")]
    private Vector3 additionalGravity;


    [SerializeField, Tooltip("Debugging if grounded or not")]
    private bool isGrounded;
    [SerializeField, Tooltip("Checks distance to ground")]
    private float groundCheckDistance = 0.2f;
    [SerializeField, Tooltip("Dictates what is the ground layer")]
    private LayerMask groundMask;

    private Animator animator; 

    private Vector2 movement;
    private Vector3 moveVector;

    private Rigidbody rb;

    float smoothTurnVelocity;
   
    #region setup
    private void OnEnable() {
        if (movementControl != null) movementControl.action.Enable();
        if (jumpControl != null) jumpControl.action.Enable();
        if (runControl != null) runControl.action.Enable();
        if (menuControl != null) menuControl.action.Enable();
    }

    private void OnDisable() {
        if (movementControl != null) movementControl.action.Disable();
        if (jumpControl != null) jumpControl.action.Disable();
        if (runControl != null) runControl.action.Disable();
        if (menuControl != null) menuControl.action.Disable();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion setup
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position,groundCheckDistance, groundMask);

        movement = movementControl.action.ReadValue<Vector2>();
        moveVector = new Vector3(movement.x, 0f, movement.y);
        moveVector = cameraMainTransform.forward * moveVector.z + cameraMainTransform.right * moveVector.x;
        moveVector.y = 0f;
        if (moveVector != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (jumpControl.action.triggered && isGrounded)
        {
            animator.SetTrigger("Jumping");
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }

        if (isGrounded)
        {
            if (moveVector != Vector3.zero && runControl.action.ReadValue<float>() == 0)
            {
                animator.SetFloat("Speed", 0.33f, animationSmoothing, Time.deltaTime);
            }
            else if (moveVector != Vector3.zero && runControl.action.ReadValue<float>() > 0)
            {
                animator.SetFloat("Speed", 1.00f, animationSmoothing, Time.deltaTime);
            }
            else if (moveVector == Vector3.zero)
            {
                animator.SetFloat("Speed", 0.0f, animationSmoothing, Time.deltaTime);
            }
        }
        if (!isGrounded)
        {
            animator.SetBool("Falling", true);
        }
        else
        {
            animator.SetBool("Falling", false);
        } 

        // Cursor Locking
        if(menuControl.action.triggered)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate(){
        if (!isGrounded)
        {
            rb.AddForce(additionalGravity);
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
                moveVector.x = contact.normal.x;
                moveVector.z = contact.normal.z;
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
                float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnSpeed);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                Debug.DrawRay(contact.point, Vector3.up.normalized, Color.red, 40f);
            }
        }
    }
    
}