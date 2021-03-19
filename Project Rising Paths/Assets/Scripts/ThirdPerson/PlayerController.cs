using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Character Controller using Input System and Cinemachine
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Input action Vector2 movement")]
    private InputActionReference movementControl = null;
    [SerializeField, Tooltip("Input action for button/float jump")]
    private InputActionReference jumpControl = null;
    [SerializeField, Tooltip("Speed multiplier")]
    private float playerSpeed = 2.0f;
    [SerializeField, Tooltip("How high can the player jump")]
    private float jumpHeight = 1.0f;
    [SerializeField, Tooltip("Value of gravity, must be negative (unless you want your player to go upwards)")]
    private float gravityValue = -9.81f;
    [SerializeField, Tooltip("Rotation speed multiplier")]
    private float rotationSpeed = 4f;
    private Vector3 moveVector;
    private Vector3 lastMove;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool doubleJump = false;
    
    private bool groundedPlayer;
    private Transform cameraMainTransform;

    #region setup

    private void OnEnable() {
        if (movementControl != null) movementControl.action.Enable();
        if (jumpControl != null) jumpControl.action.Enable();
    }

    private void OnDisable() {
        if (movementControl != null) movementControl.action.Disable();
        if (jumpControl != null) jumpControl.action.Disable();
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        // Make sure you have the camera tagged as main
        cameraMainTransform = Camera.main.transform;
    }

    #endregion setup

    void Update()
    {
        moveVector = Vector3.zero;
        groundedPlayer = controller.isGrounded;
        // Set velocity to 0 is the player is grounded to prevent vertical movement
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get movement Vector via input system and multiply by camera orientation
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player
        if (jumpControl.action.triggered && groundedPlayer)
        {
            doubleJump = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        else {
            if (jumpControl.action.triggered  && doubleJump == false){
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                doubleJump = true;
                moveVector = lastMove;
            }
        }

        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Rotate the player in accordance with their movement
        if (movement != Vector2.zero) {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

    }
    private void OnControllerColliderHit (ControllerColliderHit hit){
        if (!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if (jumpControl.action.triggered)
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            //Vector2 movement = movementControl.action.ReadValue<Vector2>();
            playerVelocity.x += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //moveVector = hit.normal * playerSpeed;
        }
    }
}