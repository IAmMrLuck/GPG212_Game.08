using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonMovement : MonoBehaviour

    // FOLLOW STATE
    // Once the player gets a bone from the Skeleton
    // The Skeleton will enter this state

{
    [SerializeField] private GameObject dogPlayer;
    private Transform dogTarget;
    [SerializeField] private float moveSpeed = 5f;
    private NavMeshAgent skelNavMeshAgent;
    

    private void Start()
    {
        skelNavMeshAgent = GetComponent<NavMeshAgent>();
        dogTarget = dogPlayer.transform;
    }

    private void FixedUpdate()
    {
        DogsDesitination();
    }

    private void DogsDesitination()
    {
        skelNavMeshAgent.SetDestination(dogTarget.position);
    }
}
