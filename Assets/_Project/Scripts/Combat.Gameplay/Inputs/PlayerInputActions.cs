// GENERATED AUTOMATICALLY FROM 'Assets/_Project/Inputs/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""LandControls"",
            ""id"": ""16765e3b-3e5d-4844-a706-85b0b03d29ff"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6c917329-d1c1-4007-a48a-0a7e2e7cd179"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da885e0a-84b4-4af1-aa9e-2cf306fd546d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9d758457-5d15-4f30-a83f-6f36e0f663ba"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""25ce93b2-791b-4ab3-aac1-46335c7b3f9d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b0edce5c-bf81-472d-ad16-4ecf2efafb74"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3f567988-f13f-47e1-9430-24076aa4a77f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5d38dfa-83d6-4262-a378-0d14ab53f2cd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a7e17235-e6cf-4fbe-82fc-b154dbc66481"",
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
        // LandControls
        m_LandControls = asset.FindActionMap("LandControls", throwIfNotFound: true);
        m_LandControls_Movement = m_LandControls.FindAction("Movement", throwIfNotFound: true);
        m_LandControls_MouseLook = m_LandControls.FindAction("MouseLook", throwIfNotFound: true);
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

    // LandControls
    private readonly InputActionMap m_LandControls;
    private ILandControlsActions m_LandControlsActionsCallbackInterface;
    private readonly InputAction m_LandControls_Movement;
    private readonly InputAction m_LandControls_MouseLook;
    public struct LandControlsActions
    {
        private @PlayerInputs m_Wrapper;
        public LandControlsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_LandControls_Movement;
        public InputAction @MouseLook => m_Wrapper.m_LandControls_MouseLook;
        public InputActionMap Get() { return m_Wrapper.m_LandControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandControlsActions set) { return set.Get(); }
        public void SetCallbacks(ILandControlsActions instance)
        {
            if (m_Wrapper.m_LandControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMovement;
                @MouseLook.started -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_LandControlsActionsCallbackInterface.OnMouseLook;
            }
            m_Wrapper.m_LandControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
            }
        }
    }
    public LandControlsActions @LandControls => new LandControlsActions(this);
    public interface ILandControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseLook(InputAction.CallbackContext context);
    }
}
