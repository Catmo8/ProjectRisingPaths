using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class LocomotionController : MonoBehaviour
{
    public GameObject leftTeleportRay;
    public GameObject rightTeleportRay;

    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;

    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;

    public InputActionAsset inputActionAsset;
    private InputActionMap leftMapXR;
    private InputActionMap rightMapXR;

    private InputAction leftButtonXR;
    private InputAction rightButtonXR;

    void Start()
    {
        leftMapXR = inputActionAsset.FindActionMap("XRI LeftHand");
        rightMapXR = inputActionAsset.FindActionMap("XRI RightHand");

        leftMapXR.Enable();
        rightMapXR.Enable();

        leftButtonXR = leftMapXR.FindAction("Teleport Select");
        rightButtonXR = rightMapXR.FindAction("Teleport Select");
    }


    private void OnDisable()
    {
        leftButtonXR.Disable();
        rightButtonXR.Disable();
    }

    // Enables or disables teleport ray for a hand when grabbing or interacting
    // with "Grab" and "UI" layers
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;
        bool isLeftInteractorRayHovering = leftInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);
        bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);

        if (!isLeftInteractorRayHovering && EnableLeftTeleport && leftButtonXR.ReadValue<float>() > 0)
        {
            if (rightButtonXR.ReadValue<float>() == 0)
                leftTeleportRay.SetActive(true);
        }
        else
        {
            leftTeleportRay.SetActive(false);
        }

        if (!isRightInteractorRayHovering && EnableRightTeleport && rightButtonXR .ReadValue<float>() > 0)
        {
            if (leftButtonXR.ReadValue<float>() == 0)
                rightTeleportRay.SetActive(true);
        }
        else
        {
            rightTeleportRay.SetActive(false);
        }
    }
}
