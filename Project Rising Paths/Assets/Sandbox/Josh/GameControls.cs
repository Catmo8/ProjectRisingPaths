// GENERATED AUTOMATICALLY FROM 'Assets/Sandbox/Josh/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""9104fe33-eef2-4939-9572-704bf99ced63"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""0df7e3f1-25e0-49b2-bdbc-4d11312da681"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""4c0703ff-9264-420a-b0c7-fa2d189222b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1d42b6f5-fe63-463c-b8c4-5a68b6d78048"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b15e9445-86df-4102-aaf2-f6b4e11309c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""769fcc02-6897-4a33-83f2-ffb55b31c4aa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""50e43386-5507-4674-ba01-85efa21ac5b2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4571cbc8-0f5c-4889-928a-4a5386029728"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e1f6dea-1d17-4cdc-a865-50af9c24c66e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""75b2512c-c215-40c7-8b31-fa2a2fe62ac0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""be9ab081-dc68-4c9d-9f79-d5044938339f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06ec9ca8-c098-4e38-b1b2-0d72472ddae2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e141596c-5323-45b5-b981-1e8b98b252c5"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ad0f529-ddfa-4429-9ab5-c746067c3814"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e31ed52f-1c96-40a6-8fdf-6fbb04067339"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e0b4df86-da55-434a-b1d0-999f554d50c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""62d6dd2c-17a1-42af-b09f-b85fdc60c4c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c76f4a19-2f30-4738-81c4-80651ed1a991"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c0de9fef-3a83-4a7f-abb9-9dc4a488d419"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6ad0abfd-5598-4b3d-92ea-b8d608e2c9ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""969f9214-0a2c-4eb4-9221-285185901e18"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf1ecb0b-2fde-4273-be85-ed91457ba279"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2282632-2f8d-4bbb-85f5-e9ac8ea8e985"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GameControls"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GameControls"",
            ""bindingGroup"": ""GameControls"",
            ""devices"": []
        }
    ]
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Newaction = m_GamePlay.FindAction("New action", throwIfNotFound: true);
        m_GamePlay_Fire = m_GamePlay.FindAction("Fire", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Move = m_GamePlay.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Look = m_GamePlay.FindAction("Look", throwIfNotFound: true);
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Newaction;
    private readonly InputAction m_GamePlay_Fire;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Look;
    public struct GamePlayActions
    {
        private @GameControls m_Wrapper;
        public GamePlayActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_GamePlay_Newaction;
        public InputAction @Fire => m_Wrapper.m_GamePlay_Fire;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Look => m_Wrapper.m_GamePlay_Look;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNewaction;
                @Fire.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnFire;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_GameControlsSchemeIndex = -1;
    public InputControlScheme GameControlsScheme
    {
        get
        {
            if (m_GameControlsSchemeIndex == -1) m_GameControlsSchemeIndex = asset.FindControlSchemeIndex("GameControls");
            return asset.controlSchemes[m_GameControlsSchemeIndex];
        }
    }
    public interface IGamePlayActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
