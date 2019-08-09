using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;
using Object = UnityEngine.Object;

public class BossController : MonoBehaviour, IHit
{
	public enum STATE
	{
		FOLLOW,
		ATTACK
	}

	//============================================================================================================//

	[SerializeField, FoldoutGroup("General")]
	private Animator animator;

	private readonly List<string> animatorNames = new List<string>()
	{
		"Forward", //[0] Float
		"Dead", //[1] Bool
		"Attack", //[2] Trigger
		"Mid Life", //[3] Trigger
		"Taunt", //[4] Trigger

    };

	private List<int> animatorHash;

	//============================================================================================================//
	
	[SerializeField, ReadOnly, FoldoutGroup("State Machine")]
	private STATE currentState = STATE.FOLLOW;

	[SerializeField]
	private GameObject specialAttack;

	[FoldoutGroup("State Machine/Combat")]
	public bool Invulnerable = false;
	[SerializeField, FoldoutGroup("State Machine/Combat")]
	private float attackTimer;
	[SerializeField, FoldoutGroup("State Machine/Combat")]
	private string searchForTag = "";
	[SerializeField, FoldoutGroup("State Machine/Combat"), Required]
	private Transform playerTransform;
	[SerializeField, FoldoutGroup("State Machine/Combat"), Required]
	private Collider hitCollider;

	[SerializeField, FoldoutGroup("State Machine/Combat")]
	private float attackDistance;

	[SerializeField, FoldoutGroup("Movement")]
	private float speed;
	[SerializeField, FoldoutGroup("Movement")]
	private float turnSpeed;

	//============================================================================================================//

	[SerializeField, FoldoutGroup("Particles")]
	private GameObject particlesPrefab;
	[SerializeField, FoldoutGroup("Particles")]
	private Transform spawnPositionTransform;

	//============================================================================================================//

	private new Transform transform;

	private float globalTimer = 0f;

	//============================================================================================================//


	// Start is called before the first frame update
	void Start()
    {
		transform = gameObject.transform;


		if (!hitCollider.isTrigger)
			throw new System.Exception($"Collider {hitCollider.gameObject.name} must be set as Trigger");

		hitCollider.gameObject.SetActive(false);

		InitAnimator();

		//currentState = STATE.FOLLOW;
		InitState(STATE.FOLLOW);
	}

	private void Update()
	{
		switch (currentState)
		{
			case STATE.FOLLOW:
				FollowState();
				break;
			case STATE.ATTACK:
				AttackState();
				break;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag(searchForTag))
		{

		}
	}

	//============================================================================================================//

	private void InitAnimator()
	{
		animatorHash = new List<int>();
		foreach (var name in animatorNames)
		{
			animatorHash.Add(Animator.StringToHash(name));
		}
	}

	private void InitState(STATE nextState)
	{
		currentState = nextState;

		switch (currentState)
		{
			case STATE.FOLLOW:
				animator.SetFloat(animatorHash[0], 1f);
				break;
			case STATE.ATTACK:
				Invulnerable = true;
				animator.SetFloat(animatorHash[0], 0f);
				animator.SetTrigger(animatorHash[2]);
				globalTimer = 0f;
				break;
			default:
				break;
		}
	}

	private void AttackState()
	{
		//TODO Wait for the attack state to finish before moving on
		//TODO Need to make it so that this character can't be hit

		if (globalTimer >= attackTimer)
		{
			InitState(STATE.FOLLOW);
		}
		else
			globalTimer += Time.deltaTime;
	}

	private void FollowState()
	{
		if(Vector3.Distance(transform.position, playerTransform.position) > attackDistance)
		{
			var direction = playerTransform.position - transform.position;
			//TODO Follow the player
			var newDirection = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0f);
			transform.rotation = Quaternion.LookRotation(newDirection);

			transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

		}
		else
		{
			//TODO Change to the attack state
			InitState(STATE.ATTACK);
		}
	}

	//private Dictionary<Type, Stack<GameObject>> recyclingBin;
	//public bool TryGetObject<T>(Type type, bool Enable = true, out T obj) where  T : MonoBehaviour
	//{
	//	obj = null;
	//	
	//	if (!recyclingBin.ContainsKey(type))
	//		return false;
//
	//	var gObject = recyclingBin[typeof(type)].Pop();
//
	//	obj = gObject.GetComponent<T>();
//
	//	gObject.SetActive(Enable);
//
	//	return true;
//
	//}

	//============================================================================================================//

	void Particles()
	{
		SpecialAttack temp= Instantiate(specialAttack).GetComponent<SpecialAttack>();

		//if (!TryGetObject<SpecialAttack>(typeof(SpecialAttack),true, out temp))
		//{
		//	temp = Instantiate(specialAttack).GetComponent<SpecialAttack>();
		//}
		//var obj = Instantiate(specialAttack).GetComponent<SpecialAttack>();
		
		temp.Init(spawnPositionTransform.position, playerTransform.position - transform.position);


		Instantiate(particlesPrefab, spawnPositionTransform.position + Vector3.up, Quaternion.Euler(new Vector3(-90f, 0f,0f)));

		Invulnerable = false;
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

	//============================================================================================================//


#if UNITY_EDITOR

	private void OnDrawGizmos()
	{
		if (!transform)
			transform = gameObject.transform;

		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(transform.position, attackDistance);
	}

#endif
}
