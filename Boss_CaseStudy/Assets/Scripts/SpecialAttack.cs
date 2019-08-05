using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SpecialAttack : MonoBehaviour
{
	private bool Triggered;

	[SerializeField]
	private float totalTime;

	[SerializeField]
	private float Distance;

	[SerializeField, Range(1,10)]
	private int Frequency;

	[SerializeField]
	private Vector3 MaxPositionOffset;
	[SerializeField]
	private Vector3 MaxRotationOffset;
	[SerializeField]
	private Vector3 MaxScaleOffset;
	[SerializeField]
	private GameObject repeatingPrefab;

	private List<GameObject> gameObjects;

	private new Transform transform;
    // Start is called before the first frame update
    void Start()
    {

		transform = gameObject.transform;

	}

	public void Init(Vector3 StartPostion, Vector3 direction)
	{
		if (Triggered)
			return;

		if (!transform)
			transform = gameObject.transform;

		transform.position = StartPostion;
		transform.forward = direction.normalized;

		gameObjects = new List<GameObject>();

		StartCoroutine(InitAttackCoroutine(direction.normalized));

		Triggered = true;
	}

	IEnumerator InitAttackCoroutine(Vector3 normalizedDirection)
	{
		Vector3 currentPosition = transform.position;

		int count = Mathf.FloorToInt(Distance * (float)Frequency);


		float offset = Distance / count;

		float timeDelay = totalTime / (float)count;

		Debug.LogError($"offset: {offset}, count: {count}, timeDelay: {timeDelay}");

		for (var i = 0; i < count; i++)
		{
			SpawnObject(currentPosition);
			yield return new WaitForSeconds(timeDelay);

			currentPosition += normalizedDirection * offset;
		}

		gameObjects.Reverse();
		yield return new WaitForSeconds(2f);

		//TODO Get rid of the objects nicely
		for (var i = gameObjects.Count - 1; i >=0; i--)
		{
			Destroy(gameObjects[i]);
			yield return new WaitForSeconds(timeDelay);
		}

		Triggered = false;
	}

	private void SpawnObject(Vector3 position)
	{
		Vector3 pos = position +
			(Vector3.right * Random.Range(-MaxPositionOffset.x, MaxPositionOffset.x)) +
			(Vector3.up * Random.Range(-MaxPositionOffset.y, MaxPositionOffset.y)) +
			(Vector3.forward * Random.Range(-MaxPositionOffset.z, MaxPositionOffset.z));

		Quaternion rot = Quaternion.Euler(
			(Vector3.right * Random.Range(-MaxRotationOffset.x, MaxRotationOffset.x)) +
			(Vector3.up * Random.Range(-MaxRotationOffset.y, MaxRotationOffset.y)) +
			(Vector3.forward * Random.Range(-MaxRotationOffset.z, MaxRotationOffset.z)));

		var trans = Instantiate(repeatingPrefab, pos, rot).transform;
		trans.localScale += new Vector3(
			Random.Range(0, MaxScaleOffset.x),
			Random.Range(0, MaxScaleOffset.y),
			Random.Range(0, MaxScaleOffset.z));
		trans.parent = transform;

		//TODO Store this to nicely scale this up/down
		gameObjects.Add(trans.gameObject);
	}


#if UNITY_EDITOR

	[Button("Trigger")]
	private void Trigger()
	{
		Init(transform.position, transform.forward);
	}

	private void OnDrawGizmos()
	{
		if (!transform)
			transform = gameObject.transform;

		//Gizmos.matrix = transform.worldToLocalMatrix;

		Gizmos.color = Color.red;

		Vector3 center = (transform.position + (transform.position + (transform.forward.normalized * Distance)))/2f;
		//center.y += MaxPositionOffset.y / 2f;
		//center.x += MaxPositionOffset.x / 2f;

		Gizmos.DrawWireCube(center, new Vector3(MaxPositionOffset.x / 2f, MaxPositionOffset.y / 2f, Distance));
	}


#endif
}
