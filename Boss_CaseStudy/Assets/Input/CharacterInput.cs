// GENERATED AUTOMATICALLY FROM 'Assets/Input/CharacterInput.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CharacterInput : IInputActionCollection
{
    private InputActionAsset asset;
    public CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""c9a11da1-cb8d-4336-88fc-1870abbd9e85"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""55858bf2-f1a8-4bed-b2db-54d65c5b2ce9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RollLeft"",
                    ""type"": ""Button"",
                    ""id"": ""8b1e5949-7f71-4902-ace3-6e3839433a3c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""RollForward"",
                    ""type"": ""Button"",
                    ""id"": ""4c202c60-9160-4039-9c10-698c92e8701b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""RollRight"",
                    ""type"": ""Button"",
                    ""id"": ""9521593d-cc25-4749-9636-22c1f0213ec8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""RollBackward"",
                    ""type"": ""Button"",
                    ""id"": ""ebbff3c0-0d0c-44cf-b3ee-9aa269d064bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bd123102-bb50-40e0-81ed-4676075ae3b6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""108a23c8-a833-4f01-9a7b-46726eee0974"",
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
                    ""id"": ""f64d7f50-a47d-41f8-a8d6-8b7ed3fc8c53"",
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
                    ""id"": ""6d0e462c-d012-40cb-8739-2f5167987df5"",
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
                    ""id"": ""c7f41c34-173a-4dd6-af2d-8cbb6e8dcc30"",
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
                    ""id"": ""94e4dc4d-e293-4155-a461-47c1864a4bc1"",
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
                    ""id"": ""8ba19bed-8d07-43dd-820f-2ee7ed00d05c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c63c1922-7105-4457-afa3-012603f9831f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f82b5426-14cf-462d-8e32-f022e00a1290"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33c370a9-24ec-4ff8-9300-2dcf1c0664cc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RollBackward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c886460d-14f2-445a-8338-64c01365f4fe"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.GetActionMap("Character");
        m_Character_Movement = m_Character.GetAction("Movement");
        m_Character_RollLeft = m_Character.GetAction("RollLeft");
        m_Character_RollForward = m_Character.GetAction("RollForward");
        m_Character_RollRight = m_Character.GetAction("RollRight");
        m_Character_RollBackward = m_Character.GetAction("RollBackward");
        m_Character_Jump = m_Character.GetAction("Jump");
    }

    ~CharacterInput()
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_RollLeft;
    private readonly InputAction m_Character_RollForward;
    private readonly InputAction m_Character_RollRight;
    private readonly InputAction m_Character_RollBackward;
    private readonly InputAction m_Character_Jump;
    public struct CharacterActions
    {
        private CharacterInput m_Wrapper;
        public CharacterActions(CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @RollLeft => m_Wrapper.m_Character_RollLeft;
        public InputAction @RollForward => m_Wrapper.m_Character_RollForward;
        public InputAction @RollRight => m_Wrapper.m_Character_RollRight;
        public InputAction @RollBackward => m_Wrapper.m_Character_RollBackward;
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                RollLeft.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollLeft;
                RollLeft.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollLeft;
                RollLeft.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollLeft;
                RollForward.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollForward;
                RollForward.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollForward;
                RollForward.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollForward;
                RollRight.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollRight;
                RollRight.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollRight;
                RollRight.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollRight;
                RollBackward.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollBackward;
                RollBackward.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollBackward;
                RollBackward.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnRollBackward;
                Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                RollLeft.started += instance.OnRollLeft;
                RollLeft.performed += instance.OnRollLeft;
                RollLeft.canceled += instance.OnRollLeft;
                RollForward.started += instance.OnRollForward;
                RollForward.performed += instance.OnRollForward;
                RollForward.canceled += instance.OnRollForward;
                RollRight.started += instance.OnRollRight;
                RollRight.performed += instance.OnRollRight;
                RollRight.canceled += instance.OnRollRight;
                RollBackward.started += instance.OnRollBackward;
                RollBackward.performed += instance.OnRollBackward;
                RollBackward.canceled += instance.OnRollBackward;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRollLeft(InputAction.CallbackContext context);
        void OnRollForward(InputAction.CallbackContext context);
        void OnRollRight(InputAction.CallbackContext context);
        void OnRollBackward(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
