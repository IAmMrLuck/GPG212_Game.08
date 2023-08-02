using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TextRoam : MonoBehaviour
{

    public bool HasDestination = false;
    public GameObject SkeleGO;
    public Vector3 Destination;
    public float MinRoamingRange = 5;
    public float MaxRoamingRange = 6;

    public NavMeshAgent SkelNavMeshAgent;


    private void Update()
    {
        if (!HasDestination)
        {
            Debug.Log("Has Destination is " + HasDestination);
            FindDestination();
        }

        else
        {
            GoToDesitination();
            Debug.Log("Else'd");

        }
    }

    private void FindDestination()
    {
        float roamingRange = Random.Range(MinRoamingRange, MaxRoamingRange);

        Debug.Log("Distance was " + roamingRange);
        Destination = SkeleGO.transform.position + Random.insideUnitSphere * roamingRange;

        HasDestination = true;
        Debug.Log("Has Destination is " + HasDestination);
    }

    private void GoToDesitination()
    {
        Debug.Log("Desitnation is " + Destination);

        SkelNavMeshAgent.SetDestination(Destination);
        Debug.Log("Did Go To destination");

        HasDestination = false;
        Debug.Log("Has Destination is now " + HasDestination);
    }
}
