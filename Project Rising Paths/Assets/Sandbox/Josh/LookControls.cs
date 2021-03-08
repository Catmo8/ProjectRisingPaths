// GENERATED AUTOMATICALLY FROM 'Assets/Sandbox/Josh/LookControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @LookControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @LookControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LookControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""147f3dab-e287-4462-97c4-daf2de183c36"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7e043870-ca66-4a15-a0fb-a0fb3d19770d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0d79872-45e0-4bb8-99c8-bb5fc23dc3ad"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MouseLook = m_Mouse.FindAction("MouseLook", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MouseLook;
    public struct MouseActions
    {
        private @LookControls m_Wrapper;
        public MouseActions(@LookControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_Mouse_MouseLook;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MouseLook.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMouseActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
    }
}
