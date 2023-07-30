using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeleRoam : MonoBehaviour
{

    [SerializeField] private float minRoamingRange = 5f;
    [SerializeField] private float maxRoamingRange = 15f;
    [SerializeField] private float moveSpeed = 5f;
    private NavMeshAgent skelNavMeshAgent;
    private bool hasDestination = false;
    private Vector3 destination;

    private void Start()
    {
        skelNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if(!hasDestination)
        {
            FindDestination();
        }
        else
        {
            GoToDesitination();
        }
    }

    private void FindDestination()
    {
        float roamingRange = Random.Range(minRoamingRange, maxRoamingRange);
        Debug.Log("Distance was " + roamingRange);
        destination = transform.position + Random.insideUnitSphere * roamingRange;

        hasDestination = true;
    }

    private void GoToDesitination()
    {
        skelNavMeshAgent.SetDestination(destination);
        hasDestination = false;
    }
}
