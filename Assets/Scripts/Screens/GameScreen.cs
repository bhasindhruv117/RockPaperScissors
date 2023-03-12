using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    #region CONSTANTS/READONLY

    private static readonly Vector3 INITIAL_PROGRESSBAR_SCALE = new Vector3(0, 1, 1);

    #endregion
    
    #region REFERENCES

    [SerializeField] private GameObject _opponentMoveGameObject;
    [SerializeField] private TMP_Text _opponentMoveText;

    [SerializeField] private GameObject _playerMoveGameObject;
    [SerializeField] private TMP_Text _playerMoveText;

    [SerializeField] private RectTransform _progressBar;

    [SerializeField] private TMP_Text _currentScoreText;

    #endregion

    #region EVENTS

    private static Action OnBotMovePlayed;

    public static void RaiseOnBotMovePlayed()
    {
        OnBotMovePlayed?.Invoke();
    }

    private static Action OnStartPlayerTurn;

    public static void RaiseOnStartPlayerTurn()
    {
        OnStartPlayerTurn?.Invoke();
    }

    private static Action<MoveType> OnTurnPlayed;

    public static void RaiseOnTurnPlayed(MoveType moveType)
    {
        OnTurnPlayed?.Invoke(moveType);
    }

    #endregion

    #region PRIVATE_VARIABLES

    private Tween _progressBarTween;

    #endregion

    public MultiPlayerGame CurrentlyPlayedGame => GameStateMachine.Instance.CurrentMultiPlayerGame;

    private void OnEnable()
    {
        OnBotMovePlayed += UpdateBotMove;
        OnStartPlayerTurn += StartPlayerTurn;
        OnTurnPlayed += TurnPlayed;
    }

    private void StartPlayerTurn()
    {
        _progressBarTween = _progressBar.DOScaleX(1, MultiPlayerGame.PLAYER_TURN_TIME).OnComplete(()=>PlayerTurnTimeComplete());
    }

    private void PlayerTurnTimeComplete()
    {
        if (!GameStateMachine.Instance.IsResultState()) {
            Invoke("EvaluateRoundResult",0.5f);
        }
    }

    private void UpdateBotMove()
    {
        _opponentMoveGameObject.SetActive(true);
        _opponentMoveText.text = CurrentlyPlayedGame.OpponentMoveType.ToString();
    }

    public void TurnPlayed(MoveType moveType = MoveType.None)
    {
        if (GameStateMachine.Instance.IsPlayerMove())
        {
            GameStateMachine.Instance.CurrentMultiPlayerGame.TurnPlayed(moveType);
            UpdatePlayerMove(moveType);
            _progressBarTween.Kill();
            Invoke("EvaluateRoundResult",1f);
        }
    }

    private void EvaluateRoundResult()
    {
        GameStateMachine.RaiseGoToState(typeof(ResultState));
    }

    private void UpdatePlayerMove(MoveType moveType)
    {
        _playerMoveGameObject.SetActive(true);
        _playerMoveText.text = moveType.ToString();
    }

    public void InitializeScreen()
    {
        _playerMoveGameObject.SetActive(false);
        _opponentMoveGameObject.SetActive(false);
        _progressBar.localScale = INITIAL_PROGRESSBAR_SCALE;
        _currentScoreText.text = CurrentlyPlayedGame.RoundNumber.ToString();
    }

    private void OnDisable()
    {
        OnBotMovePlayed += UpdateBotMove;
        OnStartPlayerTurn -= StartPlayerTurn;
        OnTurnPlayed -= TurnPlayed;
    }
}
