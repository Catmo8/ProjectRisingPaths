using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class ThirdPlayerController : MonoBehaviour
{
    public GameObject projectile;

    public InputActionAsset actionAsset;
    private InputActionMap gameplayMap;
    private InputAction fireAction;
    private InputAction moveAction;
    private InputAction lookAction;
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private Vector2 rotation;

    void Start()
    {
        gameplayMap = actionAsset.FindActionMap("GamePlay");

        gameplayMap.Enable();

        fireAction = gameplayMap.FindAction("Fire");
        moveAction = gameplayMap.FindAction("Move");
        lookAction = gameplayMap.FindAction("Look");

        fireAction.performed += context => OnFire(context);

        moveAction.performed += context => OnMove(context);
        moveAction.canceled += ctx => OnMove(ctx);

        lookAction.performed += context => OnLook(context);
        lookAction.canceled += ctx => OnLook(ctx);
    }

    private void Update()
    {
        Move(moveDirection);
        Look(lookDirection);
    }

    //Method for firing projectile.
    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log(context.phase.ToString());
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward*0.5f, Quaternion.identity);
            newProjectile.GetComponent<Rigidbody>().AddForce(20f*transform.forward, ForceMode.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase.ToString());
        moveDirection = context.ReadValue<Vector2>();
    }

    public void Move(Vector2 direction)
    {
        float moveSpeed = 5f;

        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(moveDirection.x, 0, moveDirection.y);

        transform.position += move * moveSpeed;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase.ToString());
        lookDirection = context.ReadValue<Vector2>();
    }

    private void Look(Vector2 direction)
    {
        float rotationSpeed = 50*Time.deltaTime;
        rotation.y += direction.x * rotationSpeed;

        rotation.y += direction.x * rotationSpeed;
        rotation.x = Mathf.Clamp(rotation.x - direction.y * rotationSpeed, -89, 89);

        transform.localEulerAngles = rotation;
    }
    
}
