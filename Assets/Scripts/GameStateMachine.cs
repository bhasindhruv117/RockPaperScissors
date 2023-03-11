using System;
using System.Collections.Generic;

public class GameStateMachine : GenericStateMachine
{
    private NotStartedState _notStartedState;
    private PlayerTurnState _playerTurnState;
    private OpponentTurnState _opponentTurnState;
    private ResultState _resultState;

    private Dictionary<Type, GenericState> TypeToStateMapping = new Dictionary<Type, GenericState>();

    #region GAME_STATE_EVENTS

    private static Action<Type> GoToState;

    public static void RaiseGoToState(Type state)
    {
        GoToState?.Invoke(state);
    }

    #endregion

    private void Awake()
    {
        GoToState += GoToStateHandler;
        Initialize();
    }

    private void Initialize()
    {
        _notStartedState = new NotStartedState(this);
        _playerTurnState = new PlayerTurnState(this);
        _opponentTurnState = new OpponentTurnState(this);
        _resultState = new ResultState(this);
        TypeToStateMapping.Add(typeof(NotStartedState),_notStartedState);
        TypeToStateMapping.Add(typeof(PlayerTurnState),_playerTurnState);
        TypeToStateMapping.Add(typeof(OpponentTurnState),_opponentTurnState);
        TypeToStateMapping.Add(typeof(ResultState),_resultState);
    }

    private void GoToStateHandler(Type state)
    {
        ChangeState(TypeToStateMapping[state]);
    }

    protected override GenericState GetInitialState()
    {
        return _notStartedState;
    }
}
