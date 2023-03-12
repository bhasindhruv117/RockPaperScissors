using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : GenericState
{
    public PlayerTurnState(GenericStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        GameScreen.RaiseOnStartPlayerTurn();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
