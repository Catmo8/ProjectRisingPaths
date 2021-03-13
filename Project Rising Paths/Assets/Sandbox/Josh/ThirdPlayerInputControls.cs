using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> {}
public class ThirdPlayerInputControls : MonoBehaviour
{
    Controls controls;
    public MoveInputEvent moveInputEvent;

    float horizontal;
    float vertical;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.5f;
    //private Vector2 lookDirection;
    //private Vector2 rotation;
    //private Vector2 direction;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Move.performed += OnMovePerformed;
        controls.Gameplay.Move.canceled += OnMovePerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
        //Debug.Log($"Move Input: {moveInput}");
        Debug.Log($"Move Input: {vertical}, {horizontal}");
    }

    public void OnMoveInput(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
    }
/*
    public void OnLook(InputAction.CallbackContext context)
    {
        lookDirection = context.ReadValue<Vector2>();
    }

    private void Look(Vector2 direction)
    {
        float rotationSpeed = 50*Time.deltaTime;
    }
*/
    private void Update()
    {
        Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;
       
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    /*  //Mouse Code that could not get to work
        rotation.y += direction.x * rotationSpeed;
        rotation.x = Mathf.Clamp(rotation.x-direction.y*rotationSpeed, -89, 89);
        transform.localEulerAngles =rotation;
    */
        
    }
}
