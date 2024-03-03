using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public Transform target;

	Health health;
	NavMeshAgent agent;

	void Start()
	{
		health = GetComponent<Health>();
		agent = GetComponent<NavMeshAgent>();
		if (target == null) target = GameObject.FindWithTag("Player").transform;
	}

	void Update()
	{
		agent.destination = target.position;
	}
}