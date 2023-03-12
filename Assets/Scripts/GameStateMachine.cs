using System;
using System.Collections.Generic;

public class GameStateMachine : GenericStateMachine
{
    #region SINGLETON

    private static GameStateMachine _instance;

    public static GameStateMachine Instance => _instance;

    #endregion
    
    #region PRIVATE_VARIABLES

    private MultiPlayerGame _currentMultiPlayerGame;
    
    private NotStartedState _notStartedState;
    private PlayerTurnState _playerTurnState;
    private OpponentTurnState _opponentTurnState;
    private ResultState _resultState;

    private Dictionary<Type, GenericState> TypeToStateMapping = new Dictionary<Type, GenericState>();

    #endregion
    

    #region GETTERS/SETTERS

    public MultiPlayerGame CurrentMultiPlayerGame
    {
        get => _currentMultiPlayerGame;
        set => _currentMultiPlayerGame = value;
    }

    public GenericState CurrentState => currentState;

    #endregion

    #region GAME_STATE_EVENTS

    private static Action<Type> GoToState;

    public static void RaiseGoToState(Type state)
    {
        GoToState?.Invoke(state);
    }

    #endregion

    private void Awake()
    {
        _instance = this;
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

    public bool IsPlayerMove()
    {
        return CurrentState is PlayerTurnState;
    }

    public bool IsResultState()
    {
        return CurrentState is ResultState;
    }
}
