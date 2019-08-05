using System;
using System.Collections;
using System.Collections.Generic;
using CaseStudy;
using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using Input = CaseStudy.Input;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour, IInput, IHit
{

    private readonly List<string> animatorNames = new List<string>()
    {
        "Running", //[0] Float
        "RollLeft", //[1] Trigger
        "RollForward", //[2] Trigger
        "RollRight",//[3] Trigger,
        "RollBackward",//[4]Trigger,
        "Turn",//[5] Float
        "Jump", //[6] Trigger
        "LightAttack", //[7] Bool
        "AttackCount",//[8] int
        "HeavyAttack", //[9] Bool
    };

    private List<int> animatorHash;

    [SerializeField, ReadOnly, BoxGroup("Debug Information")]
    private Vector2 playerInput;

    [SerializeField]
    private new CinemachineFreeLook camera;

    [SerializeField, ReadOnly]
    private bool lightAttacking;
    [SerializeField, ReadOnly]
    private bool heavyAttacking;
    [SerializeField, ReadOnly]
    private int attackCount;

    [SerializeField]
    private float clickCooldown = 1f;

    private float cooldownTimer;
    //================================================================================================================//

    [SerializeField, FoldoutGroup("HitBox"), Required]
    private BoxCollider hitCollider;

    [SerializeField, FoldoutGroup("HitBox"), Required]
    private GameObject[] HitParticlesPrefabs;
    
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
        InitHitCollider();

    }

    //================================================================================================================//
    private void InitHitCollider()
    {
        //Avoid Hitting ourselves
        Physics.IgnoreCollision(hitCollider, collider);
        hitCollider.gameObject.SetActive(false);
    }
    
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
        
        //Attack Combo Click Check
        //------------------------------------------------//

        if (attackCount > 0)
        {
            if (cooldownTimer >= clickCooldown)
            {
                cooldownTimer = 0f;
                attackCount = 0;
                lightAttacking = false;
                animator.SetBool(animatorHash[7], lightAttacking);

                heavyAttacking = false;
                animator.SetBool(animatorHash[9], heavyAttacking);
                //animator.SetBool(animatorHash[X], lightAttacking);
            }
            else
            {
                cooldownTimer += Time.deltaTime;
            }
        }
        
        //Force Move in Camera Forward
        //------------------------------------------------//
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


        //Rolling
        //------------------------------------------------------------------//
        
        Input.Actions.Character.RollLeft.Enable();
        Input.Actions.Character.RollLeft.performed += ctx => { animator.SetTrigger(animatorHash[1]); };
        Input.Actions.Character.RollForward.Enable();
        Input.Actions.Character.RollForward.performed += ctx => { animator.SetTrigger(animatorHash[2]); };
        Input.Actions.Character.RollRight.Enable();
        Input.Actions.Character.RollRight.performed += ctx => { animator.SetTrigger(animatorHash[3]); };
        Input.Actions.Character.RollBackward.Enable();
        Input.Actions.Character.RollBackward.performed += ctx => { animator.SetTrigger(animatorHash[4]); };

        //Jumping
        //------------------------------------------------------------------//
        
        Input.Actions.Character.Jump.Enable();
        Input.Actions.Character.Jump.performed += ctx => { animator.SetTrigger(animatorHash[6]); };
        
        //TODO I should consider being able to combine both heavy and light attacks
        //Attacking
        //------------------------------------------------------------------//
        Input.Actions.Character.LightAttack.Enable();
        Input.Actions.Character.LightAttack.performed += ctx =>
        {
            if (heavyAttacking)
                return;

            lightAttacking = true;
            cooldownTimer = 0f;
            //var count = ctx.ReadValue<int>();
            
            //Debug.Log($"Click Count: {count}");
            animator.SetBool(animatorHash[7], lightAttacking);
            animator.SetInteger(animatorHash[8], ++attackCount);
        };

        Input.Actions.Character.HeavyAttack.Enable();
        Input.Actions.Character.HeavyAttack.performed += ctx =>
        {
            if (lightAttacking)
                return;

            heavyAttacking = true;
            cooldownTimer  = 0f;

            animator.SetBool(animatorHash[9], heavyAttacking);
            animator.SetInteger(animatorHash[8], ++attackCount);
        };
    }

    public void DeinitControls()
    {
        throw new System.NotImplementedException();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Hittable"))
            return;
        
        Debug.Log($"Hit: {other.name}", other.gameObject);

        var temp = Instantiate(HitParticlesPrefabs[Random.Range(0,HitParticlesPrefabs.Length)], other.ClosestPoint(hitCollider.transform.position),
            Quaternion.identity);
    }

    public void Hit(int milliseconds)
    {
        StopCoroutine(HitCoroutine(0f));

        StartCoroutine(HitCoroutine(milliseconds / 1000f));
    }

    private IEnumerator HitCoroutine(float seconds)
    {
        hitCollider.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(seconds);
        
        hitCollider.gameObject.SetActive(false);
    }
    
}
