
public class SkeleStateFactory 
{
    SkeleStateManager context;

    public SkeleStateFactory(SkeleStateManager currentContext)
    {
        context = currentContext;
    }

    public SkeleBaseState Flee() {
        return new SkeleFlee(context, this);
            }

    public SkeleBaseState Roam( ) {
        return new SkeleRoam(context, this); 
            }

    public SkeleBaseState Chase() {
        return new SkeleChase(context, this);
            }


}
