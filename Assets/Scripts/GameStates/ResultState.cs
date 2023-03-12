using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultState : GenericState
{
    public ResultState(GenericStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        MultiPlayerGame multiPlayerGame = (stateMachine as GameStateMachine).CurrentMultiPlayerGame;
        bool isRoundWon = multiPlayerGame.IsRoundWon();
        if (isRoundWon) {
            multiPlayerGame.IncrementRoundNumber();
            multiPlayerGame.ResetMoves();
            GameStateMachine.RaiseGoToState(typeof(OpponentTurnState));
        }
        else
        {
            GameStateMachine.RaiseGoToState(typeof(NotStartedState));
        }
    }

    public override void Exit()
    {
        StatsManager.Instance.CheckAndUpdateHighScore((stateMachine as GameStateMachine).CurrentMultiPlayerGame.RoundNumber);
    }
}
