
using UnityEngine;

public class SkeleFlee : SkeleBaseState
{
    public SkeleFlee(SkeleStateManager currentContext, SkeleStateFactory skeleStateFactory)
        : base(currentContext, skeleStateFactory) { }
    public override void EnterState() {
        Debug.Log("//=====================Hello from the Flee state===================//");

    }

    public override void UpdateState() 
    {
        Vector3 vector3 = ctx.SkeleGO.transform.position - ctx.DogPlayer.transform.position;
        Vector3 newDestination = ctx.SkeleGO.transform.position + vector3;
        ctx.SkelNavMeshAgent.SetDestination(newDestination);

        CheckSwitchState();
    }

    public override void ExitState()
    {

    }
    
    public override void CheckSwitchState()
    {
        float currentDist = Vector3.Distance(ctx.SkeleGO.transform.position, ctx.DogPlayer.transform.position);

        if (currentDist > ctx.DistToPlayer)
        {
            SwitchStates(factory.Roam());
        }
    }

}
