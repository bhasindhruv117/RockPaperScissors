public class OpponentTurnState : GenericState
{
    public OpponentTurnState(GenericStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        ScreenController.RaiseOnToggleGameScreen(true);
        (stateMachine as GameStateMachine).CurrentMultiPlayerGame.SelectBotMoveForRound();
        GameScreen.RaiseOnBotMovePlayed();
        GameStateMachine.RaiseGoToState(typeof(PlayerTurnState));
    }

    public override void Exit()
    {
        
    }
}
