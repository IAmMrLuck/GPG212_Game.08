
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Rendering.DebugUI;

public class SkeleStateManager : MonoBehaviour
{

    SkeleBaseState currentState;
    SkeleStateFactory states;
    //SkeleChase ChasingState = new SkeleChase();
    //SkeleFlee FleeingState = new SkeleFlee();
    //SkeleRoam RoamingState = new SkeleRoam();


    [SerializeField] private float _minRoamingRange = 5f;
    [SerializeField] private float _maxRoamingRange = 15f;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private NavMeshAgent _skelNavMeshAgent;
    private bool _hasDestination = false;
    private Vector3 _destination;

    [SerializeField] private GameObject _skeleGO;
    [SerializeField] private GameObject _dogPlayer;
    private Transform _dogTarget;

    [SerializeField] private float _distToPlayer;



    public SkeleBaseState CurrentState { get { return currentState; } set { currentState = value; } }

    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float MinRoamingRange { get { return _minRoamingRange; } set { _minRoamingRange = value; } }
    public float MaxRoamingRange { get { return _maxRoamingRange; } set { _maxRoamingRange = value; } }
    public NavMeshAgent SkelNavMeshAgent { get { return _skelNavMeshAgent; }}
    public bool HasDestination { get { return _hasDestination; } set { _hasDestination = value ; } }
    public Vector3 Destination { get { return _destination; } set { _destination = value; } }
    public Transform DogTarget { get { return _dogTarget; } set { _dogTarget = value; } }
    public GameObject DogPlayer { get { return _dogPlayer; } set { _dogPlayer = value; } }
    public GameObject SkeleGO { get { return _skeleGO; } set { _skeleGO = value; } }
    public float DistToPlayer { get { return _distToPlayer; } set { _distToPlayer = value; } }


    private void Awake()
    {
        _skelNavMeshAgent.GetComponent<NavMeshAgent>();
        _dogTarget = _dogPlayer.transform;

        states = new SkeleStateFactory(this);
        currentState = states.Roam();
        currentState.EnterState();

       
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

    //public void StartMovementCoroutine()
    //{
    //    StartCoroutine(MoveToDestination());
    //}

    //public IEnumerator MoveToDestination()
    //{
    //    while ()
    //    {
    //        yield return null;
    //    }

    //    _hasDestination = false;
    //}


}
