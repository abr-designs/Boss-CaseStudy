using System.Collections;
using System.Collections.Generic;
using CaseStudy;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Input = CaseStudy.Input;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour, IInput
{

    private readonly List<string> animatorNames = new List<string>()
    {
        "Running", //[0] Float
        "RollLeft", //[1] Trigger
        "RollForward", //[2] Trigger
        "RollRight",//[3] Trigger,
        "RollBackward",//[4]Trigger,
        "Turn",//[5] Float
    };

    private List<int> animatorHash;

    [SerializeField, ReadOnly, BoxGroup("Debug Information")]
    private Vector2 playerInput;

    [SerializeField]
    private new CinemachineFreeLook camera;
    //================================================================================================================//


    private new Transform transform;
    private new Rigidbody rigidbody;
    private new CapsuleCollider collider;
    private Animator animator;

    //================================================================================================================//

    // Start is called before the first frame update
    private void Start()
    {
        transform = gameObject.transform;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<CapsuleCollider>();
        animator = gameObject.GetComponent<Animator>();

        InitAnimator();

        InitControls();
    }

    //================================================================================================================//

    private void InitAnimator()
    {
        animatorHash = new List<int>();
        foreach (var name in animatorNames)
        {
            animatorHash.Add(Animator.StringToHash(name));
        }
    }

    private void LateUpdate()
    {
        if (playerInput == Vector2.zero)
            return;
        
        var camForward = (transform.position - camera.transform.position).normalized;
        camForward.y = 0f;
        transform.forward = camForward;
    }

    //================================================================================================================//

    public void InitControls()
    {
        Input.Actions.Character.Movement.Enable();
        Input.Actions.Character.Movement.performed += ctx =>
        {
            playerInput = ctx.ReadValue<Vector2>();

            

            //Set Running
            animator.SetFloat(animatorHash[0], playerInput.y);
            //Set Turn
            animator.SetFloat(animatorHash[5], playerInput.x);
        };


        Input.Actions.Character.RollLeft.Enable();
        Input.Actions.Character.RollLeft.performed += ctx => { animator.SetTrigger(animatorHash[1]); };
        Input.Actions.Character.RollForward.Enable();
        Input.Actions.Character.RollForward.performed += ctx => { animator.SetTrigger(animatorHash[2]); };
        Input.Actions.Character.RollRight.Enable();
        Input.Actions.Character.RollRight.performed += ctx => { animator.SetTrigger(animatorHash[3]); };
        Input.Actions.Character.RollBackward.Enable();
        Input.Actions.Character.RollBackward.performed += ctx => { animator.SetTrigger(animatorHash[4]); };


    }

    public void DeinitControls()
    {
        throw new System.NotImplementedException();
    }
}
