using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPlayerController2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameControls gameControls;
    public Vector2 movementInput;

    private void OnEnable()
    {
        if (gameControls == null)
        {
            gameControls = new GameControls();

            gameControls.GamePlay.Move.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        gameControls.Enable();
    }

    private void OnDisable()
    {
        gameControls.Disable();
    }
}
