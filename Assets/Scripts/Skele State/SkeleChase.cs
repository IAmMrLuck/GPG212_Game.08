

public class SkeleChase : SkeleBaseState
{
    public SkeleChase(SkeleStateManager currentContext, SkeleStateFactory skeleStateFactory)
        : base(currentContext, skeleStateFactory) { }


    public override void EnterState() 
    {
        DogsDesitination();

    }

    public override void UpdateState()
    {

    }

    public override void CheckSwitchState() 
    {
        
    }


 
    public override void ExitState()
    {

    }


    private void DogsDesitination()
    {
        ctx.SkelNavMeshAgent.SetDestination(ctx.DogTarget.position);
    }
}
