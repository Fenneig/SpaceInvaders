//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/DefenderInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @DefenderInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefenderInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefenderInput"",
    ""maps"": [
        {
            ""name"": ""Standart"",
            ""id"": ""7fe959e7-806c-4d23-8b29-b57446f75ae6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7844bd2a-5775-4476-b800-eaa8e2785c92"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""11b8952f-57a7-459d-83ed-4fda84332d37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e2b8c0f7-6f68-4a31-8396-b7babfb506a9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a665936b-747e-4520-b9bd-4a2410513dfd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""524f6752-d62a-4b3c-8e5f-5f68b3b65a75"",
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
                    ""id"": ""dff0dbde-b2e0-44be-bdf9-cf74c55ae81c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Standart
        m_Standart = asset.FindActionMap("Standart", throwIfNotFound: true);
        m_Standart_Movement = m_Standart.FindAction("Movement", throwIfNotFound: true);
        m_Standart_Shoot = m_Standart.FindAction("Shoot", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Standart
    private readonly InputActionMap m_Standart;
    private List<IStandartActions> m_StandartActionsCallbackInterfaces = new List<IStandartActions>();
    private readonly InputAction m_Standart_Movement;
    private readonly InputAction m_Standart_Shoot;
    public struct StandartActions
    {
        private @DefenderInput m_Wrapper;
        public StandartActions(@DefenderInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Standart_Movement;
        public InputAction @Shoot => m_Wrapper.m_Standart_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Standart; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandartActions set) { return set.Get(); }
        public void AddCallbacks(IStandartActions instance)
        {
            if (instance == null || m_Wrapper.m_StandartActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StandartActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IStandartActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IStandartActions instance)
        {
            if (m_Wrapper.m_StandartActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStandartActions instance)
        {
            foreach (var item in m_Wrapper.m_StandartActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StandartActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StandartActions @Standart => new StandartActions(this);
    public interface IStandartActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}