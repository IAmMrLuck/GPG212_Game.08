using UnityEngine;


public class SkeleRoam : SkeleBaseState
{
    public SkeleRoam(SkeleStateManager currentContext, SkeleStateFactory skeleStateFactory) 
        : base(currentContext, skeleStateFactory) { }

    public override void EnterState() {
        Debug.Log("//===========================Hello from the Roaming state==========================//");
        //UpdateState();

    }

    public override void UpdateState() 
    {
        if (!ctx.HasDestination)
        {
            //Debug.Log("Has Destination is " + ctx.HasDestination);
            FindDestination();
        }

        else
        {
            GoToDesitination();
            //Debug.Log("Else'd");

        }

        CheckSwitchState();
    }

    public override void CheckSwitchState() {
//       Debug.Log("Switch State Checked");

        float currentDist = Vector3.Distance(ctx.SkeleGO.transform.position, ctx.DogPlayer.transform.position);

        if (currentDist < ctx.DistToPlayer)
        {
            SwitchStates(factory.Flee());
        }

        
    }

    public override void ExitState()
    {

    }


    private void FindDestination()
    {
        float roamingRange = Random.Range(ctx.MinRoamingRange, ctx.MaxRoamingRange);

      //  Debug.Log("Distance was " + roamingRange);
        ctx.Destination = ctx.SkeleGO.transform.position + Random.insideUnitSphere * roamingRange;

        ctx.HasDestination = true;
      //  Debug.Log("Has Destination is " + ctx.HasDestination);
    }


    private void GoToDesitination()
    {
        Debug.Log("Desitnation is " + ctx.Destination);
        
        ctx.SkelNavMeshAgent.SetDestination(ctx.Destination);
        //ctx.StartCoroutine(ctx.MoveToDestination());
        ctx.HasDestination = false;

        //Debug.Log("SkelePosition " + ctx.SkeleGO.transform.position);
        //if (ctx.SkeleGO.transform.position.x != ctx.Destination.x) return;
        //if (ctx.SkeleGO.transform.position.z != ctx.Destination.z) return;

        //Debug.Log("Did Go To destination");

        // Debug.Log("Has Destination is now " + ctx.HasDestination);
    }
}
