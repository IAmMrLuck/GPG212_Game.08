using UnityEngine;


public class SkeleChase : SkeleBaseState
{
    public SkeleChase(SkeleStateManager currentContext, SkeleStateFactory skeleStateFactory)
        : base(currentContext, skeleStateFactory) { }


    public override void EnterState() 
    {
        Debug.Log("//===========================Hello from the Chase  state==========================//");

    }

    public override void UpdateState()
    {
        DogsDesitination();

        CheckSwitchState();
    }

    public override void CheckSwitchState() 
    {
        if (DogCharacter.bonePoints <1)
        {
            SwitchStates(factory.Roam());
        }
    }

    public override void ExitState()
    {

    }


    private void DogsDesitination()
    {
        ctx.SkelNavMeshAgent.SetDestination(ctx.DogTarget.position);
    }
}
