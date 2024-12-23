//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/PlayerControler.inputactions
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

public partial class @PlayerControler: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControler"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""93b4bc0a-6987-4cd6-a56e-6d22e5a7c3b4"",
            ""actions"": [
                {
                    ""name"": ""Deplacement"",
                    ""type"": ""Value"",
                    ""id"": ""d78577cd-0e82-41fa-bd5b-5bf6bca7ef4c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Value"",
                    ""id"": ""2017bcaa-bcec-49e9-a728-5b9b141fc7e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Value"",
                    ""id"": ""d21ee02a-db83-48bd-9007-f4dd2375c31c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91088921-da16-465a-a046-eb04ff8f206b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5ac90dca-fde3-4426-b34c-5ccb2a0ae305"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2e20fb1c-a90d-42b7-abdf-f5a61443299d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3dc26cc2-9a7c-4715-8730-2e757b696da4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""45998791-8cf5-4b17-bd95-5d702d0e7b03"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""be1cecbd-e0f7-4fd4-8a1a-d967b7eaa1cd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""12507f4b-0dff-4c11-9f0b-7478f9412e18"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""210375d0-f475-4891-96d4-19af1cf6c9aa"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map1"",
            ""id"": ""a0bc5e37-563e-4f84-b290-07886cbccfd4"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""0cbb1948-2c65-45b1-850c-608c964e7ead"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38b8b6b4-4820-48b4-80e9-52b774a9b115"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Deplacement = m_Player.FindAction("Deplacement", throwIfNotFound: true);
        m_Player_Boost = m_Player.FindAction("Boost", throwIfNotFound: true);
        m_Player_Menu = m_Player.FindAction("Menu", throwIfNotFound: true);
        // New action map1
        m_Newactionmap1 = asset.FindActionMap("New action map1", throwIfNotFound: true);
        m_Newactionmap1_Newaction = m_Newactionmap1.FindAction("New action", throwIfNotFound: true);
    }

    ~@PlayerControler()
    {
        UnityEngine.Debug.Assert(!m_Player.enabled, "This will cause a leak and performance issues, PlayerControler.Player.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_Newactionmap1.enabled, "This will cause a leak and performance issues, PlayerControler.Newactionmap1.Disable() has not been called.");
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Deplacement;
    private readonly InputAction m_Player_Boost;
    private readonly InputAction m_Player_Menu;
    public struct PlayerActions
    {
        private @PlayerControler m_Wrapper;
        public PlayerActions(@PlayerControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Deplacement => m_Wrapper.m_Player_Deplacement;
        public InputAction @Boost => m_Wrapper.m_Player_Boost;
        public InputAction @Menu => m_Wrapper.m_Player_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Deplacement.started += instance.OnDeplacement;
            @Deplacement.performed += instance.OnDeplacement;
            @Deplacement.canceled += instance.OnDeplacement;
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Deplacement.started -= instance.OnDeplacement;
            @Deplacement.performed -= instance.OnDeplacement;
            @Deplacement.canceled -= instance.OnDeplacement;
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // New action map1
    private readonly InputActionMap m_Newactionmap1;
    private List<INewactionmap1Actions> m_Newactionmap1ActionsCallbackInterfaces = new List<INewactionmap1Actions>();
    private readonly InputAction m_Newactionmap1_Newaction;
    public struct Newactionmap1Actions
    {
        private @PlayerControler m_Wrapper;
        public Newactionmap1Actions(@PlayerControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap1_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Newactionmap1Actions set) { return set.Get(); }
        public void AddCallbacks(INewactionmap1Actions instance)
        {
            if (instance == null || m_Wrapper.m_Newactionmap1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Newactionmap1ActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(INewactionmap1Actions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(INewactionmap1Actions instance)
        {
            if (m_Wrapper.m_Newactionmap1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INewactionmap1Actions instance)
        {
            foreach (var item in m_Wrapper.m_Newactionmap1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Newactionmap1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Newactionmap1Actions @Newactionmap1 => new Newactionmap1Actions(this);
    public interface IPlayerActions
    {
        void OnDeplacement(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
    public interface INewactionmap1Actions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
