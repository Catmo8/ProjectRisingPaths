using UnityEngine;
using UnityEngine.InputSystem;
public class CreatingActions : MonoBehaviour
{
    //Adding input actions
    InputAction fireAction = new InputAction("Fire", binding: "<Keyboard>/space"); 
    InputAction moveAction = new InputAction("Move");

    //Adding input action map
    InputActionMap gameplayMap = new InputActionMap("Gameplay");

    private void Awake()
    {
        fireAction.AddBinding("<Gampepad>/southButton");
        moveAction.AddCompositeBinding("WASD")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

            InputAction jumpAction = gameplayMap.AddAction("Jump");
            jumpAction.AddBinding("<Keyboard>/space");

            // To add multiple action maps
            InputActionAsset actionAsset = ScriptableObject.CreateInstance<InputActionAsset>();
            actionAsset.AddActionMap(gameplayMap);

            fireAction.Enable();
            gameplayMap.Enable();


    }
}
