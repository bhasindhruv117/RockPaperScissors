public class GenericState
{
    protected GenericStateMachine stateMachine;

    public GenericState(GenericStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
}