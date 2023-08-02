

public abstract class SkeleBaseState
{
    protected SkeleStateManager ctx;
    protected SkeleStateFactory factory;

    public SkeleBaseState(SkeleStateManager currentContext, SkeleStateFactory skeleStateFactory) 
    {
        ctx = currentContext;
        factory = skeleStateFactory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchState();

    protected void SwitchStates(SkeleBaseState newState)
    {
        ExitState();

        newState.EnterState();

        ctx.CurrentState = newState;
    }

}
