public class NotStartedState : GenericState
{
    public NotStartedState(GenericStateMachine stateMachine) : base(stateMachine)
    {
        
    }

    public override void Enter()
    {
        ScreenController.RaiseOnToggleMenuScreen(true);
    }

    public override void Exit()
    {
        ScreenController.RaiseOnToggleMenuScreen(false);
    }
}
