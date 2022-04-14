// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControllerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControllerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControllerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControllerInputs"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""f393790b-7123-45a7-b7fd-6f86a375fe5d"",
            ""actions"": [
                {
                    ""name"": ""SelectRing"",
                    ""type"": ""Button"",
                    ""id"": ""5b90e121-850e-4ff8-b9b0-b55265f42602"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""811aa8a5-9f45-47ea-a852-1dc586c665d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateSelectedRing"",
                    ""type"": ""Value"",
                    ""id"": ""458cae46-6a26-4548-96c9-9f377ff3d66a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""18d39fe5-eeee-4f2b-a6db-8a104618d8e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRingTwo"",
                    ""type"": ""Value"",
                    ""id"": ""07048964-2372-4d3e-b672-c44ec6273ebf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRingThree"",
                    ""type"": ""Value"",
                    ""id"": ""cc1c1162-8a1a-4ccc-aed2-58fb402da95f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRingFour"",
                    ""type"": ""Value"",
                    ""id"": ""8ed73a63-cabc-41d0-8a6d-ba3e5a01c18f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRingFive"",
                    ""type"": ""Value"",
                    ""id"": ""2cb34801-8a63-4274-b3fd-8d0284852d83"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5f925dfb-ecbd-4937-a613-ded08a7699a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectRing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""359c514f-0c7b-49b3-8c01-8b91c8ed8648"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87130ee8-b651-4fff-a8e7-093ec5f36ef6"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateSelectedRing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""1ea41ae0-038b-4057-9147-188f9502851c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingTwo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de0d6e15-0219-42c4-90b1-b0f33d218671"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""938cfeda-d1b5-403f-9a85-423cc6d99c80"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""bd3b4ea5-a3fb-419a-bad6-24eb2364d60b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingThree"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""916db46f-19db-4eb7-9048-32cc880aea10"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b32ddd12-5b3e-4e2b-bd7b-0c1b9f4f70bb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""90c0db97-abe1-489f-9688-4f6ee3aefd93"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFour"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1c74b51e-625c-4d48-a207-da0275c0cfe4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""82ba4102-3181-4239-96e3-f6240a9c0d76"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""c22f8565-3aa0-4ca0-a121-2048dd2049db"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFive"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bef35823-3b1e-4e73-9d1f-43f5aa996764"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1bea5029-8730-439b-84a7-adcea8cc58d7"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRingFive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""49a561fa-c810-429f-83a4-183dbd2cc3cb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_SelectRing = m_Default.FindAction("SelectRing", throwIfNotFound: true);
        m_Default_MousePosition = m_Default.FindAction("MousePosition", throwIfNotFound: true);
        m_Default_RotateSelectedRing = m_Default.FindAction("RotateSelectedRing", throwIfNotFound: true);
        m_Default_Fire = m_Default.FindAction("Fire", throwIfNotFound: true);
        m_Default_RotateRingTwo = m_Default.FindAction("RotateRingTwo", throwIfNotFound: true);
        m_Default_RotateRingThree = m_Default.FindAction("RotateRingThree", throwIfNotFound: true);
        m_Default_RotateRingFour = m_Default.FindAction("RotateRingFour", throwIfNotFound: true);
        m_Default_RotateRingFive = m_Default.FindAction("RotateRingFive", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_SelectRing;
    private readonly InputAction m_Default_MousePosition;
    private readonly InputAction m_Default_RotateSelectedRing;
    private readonly InputAction m_Default_Fire;
    private readonly InputAction m_Default_RotateRingTwo;
    private readonly InputAction m_Default_RotateRingThree;
    private readonly InputAction m_Default_RotateRingFour;
    private readonly InputAction m_Default_RotateRingFive;
    public struct DefaultActions
    {
        private @PlayerControllerInputs m_Wrapper;
        public DefaultActions(@PlayerControllerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectRing => m_Wrapper.m_Default_SelectRing;
        public InputAction @MousePosition => m_Wrapper.m_Default_MousePosition;
        public InputAction @RotateSelectedRing => m_Wrapper.m_Default_RotateSelectedRing;
        public InputAction @Fire => m_Wrapper.m_Default_Fire;
        public InputAction @RotateRingTwo => m_Wrapper.m_Default_RotateRingTwo;
        public InputAction @RotateRingThree => m_Wrapper.m_Default_RotateRingThree;
        public InputAction @RotateRingFour => m_Wrapper.m_Default_RotateRingFour;
        public InputAction @RotateRingFive => m_Wrapper.m_Default_RotateRingFive;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @SelectRing.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelectRing;
                @SelectRing.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelectRing;
                @SelectRing.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSelectRing;
                @MousePosition.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMousePosition;
                @RotateSelectedRing.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateSelectedRing;
                @RotateSelectedRing.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateSelectedRing;
                @RotateSelectedRing.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateSelectedRing;
                @Fire.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnFire;
                @RotateRingTwo.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingTwo;
                @RotateRingTwo.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingTwo;
                @RotateRingTwo.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingTwo;
                @RotateRingThree.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingThree;
                @RotateRingThree.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingThree;
                @RotateRingThree.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingThree;
                @RotateRingFour.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFour;
                @RotateRingFour.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFour;
                @RotateRingFour.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFour;
                @RotateRingFive.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFive;
                @RotateRingFive.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFive;
                @RotateRingFive.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnRotateRingFive;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectRing.started += instance.OnSelectRing;
                @SelectRing.performed += instance.OnSelectRing;
                @SelectRing.canceled += instance.OnSelectRing;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @RotateSelectedRing.started += instance.OnRotateSelectedRing;
                @RotateSelectedRing.performed += instance.OnRotateSelectedRing;
                @RotateSelectedRing.canceled += instance.OnRotateSelectedRing;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @RotateRingTwo.started += instance.OnRotateRingTwo;
                @RotateRingTwo.performed += instance.OnRotateRingTwo;
                @RotateRingTwo.canceled += instance.OnRotateRingTwo;
                @RotateRingThree.started += instance.OnRotateRingThree;
                @RotateRingThree.performed += instance.OnRotateRingThree;
                @RotateRingThree.canceled += instance.OnRotateRingThree;
                @RotateRingFour.started += instance.OnRotateRingFour;
                @RotateRingFour.performed += instance.OnRotateRingFour;
                @RotateRingFour.canceled += instance.OnRotateRingFour;
                @RotateRingFive.started += instance.OnRotateRingFive;
                @RotateRingFive.performed += instance.OnRotateRingFive;
                @RotateRingFive.canceled += instance.OnRotateRingFive;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnSelectRing(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRotateSelectedRing(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnRotateRingTwo(InputAction.CallbackContext context);
        void OnRotateRingThree(InputAction.CallbackContext context);
        void OnRotateRingFour(InputAction.CallbackContext context);
        void OnRotateRingFive(InputAction.CallbackContext context);
    }
}
