public class OpponentTurnState : GenericState
{
    public OpponentTurnState(GenericStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        ScreenController.RaiseOnToggleGameScreen(true);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
