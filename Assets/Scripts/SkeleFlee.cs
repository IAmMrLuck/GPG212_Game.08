using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeleFlee : MonoBehaviour
{

    private NavMeshAgent _agent;
    [SerializeField] public GameObject dogPlayer;
    [SerializeField] private float distToPlayer;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        float currentDist = Vector3.Distance(transform.position, dogPlayer.transform.position);

        if(currentDist < distToPlayer)
        {
            Vector3 vector3 = transform.position - dogPlayer.transform.position;
            Vector3 newDestination = transform.position + vector3;
            _agent.SetDestination(newDestination);
        }
    }

}
