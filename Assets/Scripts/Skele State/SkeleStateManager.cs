using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeleStateManager : MonoBehaviour
{

    SkeleBaseState currentState;
    SkeleStateFactory states;
    //SkeleChase ChasingState = new SkeleChase();
    //SkeleFlee FleeingState = new SkeleFlee();
    //SkeleRoam RoamingState = new SkeleRoam();


    [SerializeField] private float minRoamingRange = 5f;
    [SerializeField] private float maxRoamingRange = 15f;
    [SerializeField] private float moveSpeed = 5f;
    private NavMeshAgent skelNavMeshAgent;
    private bool hasDestination = false;
    private Vector3 destination;

    [SerializeField] private GameObject skeleGO;
    [SerializeField] private GameObject dogPlayer;
    private Transform dogTarget;

    [SerializeField] private float distToPlayer;



    public SkeleBaseState CurrentState { get { return currentState; } set { currentState = value; } }

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float MinRoamingRange { get { return minRoamingRange; } set { minRoamingRange = value; } }
    public float MaxRoamingRange { get { return maxRoamingRange; } set { maxRoamingRange = value; } }
    public NavMeshAgent SkelNavMeshAgent { get { return skelNavMeshAgent; } set { skelNavMeshAgent = value; } }
    public bool HasDestination { get { return hasDestination; } set { hasDestination = value ; } }
    public Vector3 Destination { get { return destination; } set { destination = value; } }
    public Transform DogTarget { get { return dogTarget; } set { dogTarget = value; } }
    public GameObject DogPlayer { get { return dogPlayer; } set { dogPlayer = value; } }
    public GameObject SkeleGO { get { return skeleGO; } set { skeleGO = value; } }
    public float DistToPlayer { get { return distToPlayer; } set { distToPlayer = value; } }


    private void Awake()
    {
        states = new SkeleStateFactory(this);
        currentState = states.Roam();
        currentState.EnterState();

        skelNavMeshAgent = GetComponent<NavMeshAgent>();
        dogTarget = dogPlayer.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        currentState.UpdateState();
    }

   
}
