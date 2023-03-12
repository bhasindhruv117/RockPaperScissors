using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerGame
{
    public const float PLAYER_TURN_TIME = 5f;
    
    private MoveType _playerMoveType;
    private MoveType _opponentMoveType;

    public MoveType OpponentMoveType => _opponentMoveType;

    public MoveType PlayerMoveType => _playerMoveType;

    private int roundNumber;

    public int RoundNumber => roundNumber;

    private readonly Dictionary<MoveType, HashSet<MoveType>> MoveTypeTrumpsOverMoveTypeMapping =
        new Dictionary<MoveType, HashSet<MoveType>>()
        {
            { MoveType.None ,new HashSet<MoveType>()},
            { MoveType.Rock, new HashSet<MoveType> { MoveType.Scissors, MoveType.Lizzard } },
            { MoveType.Paper, new HashSet<MoveType> { MoveType.Rock, MoveType.Spock } },
            { MoveType.Scissors , new HashSet<MoveType> { MoveType.Paper ,MoveType.Lizzard}},
            { MoveType.Lizzard , new HashSet<MoveType> { MoveType.Spock ,MoveType.Paper}},
            { MoveType.Spock , new HashSet<MoveType> { MoveType.Rock ,MoveType.Scissors}}
        };

    public MultiPlayerGame()
    {
        _playerMoveType = MoveType.None;
        _opponentMoveType = MoveType.None;
        roundNumber = 0;
    }

    public void TurnPlayed(MoveType moveType)
    {
        _playerMoveType = moveType;
    }

    public void SelectBotMoveForRound()
    {
        int randomeMove = Random.Range(1, 6);
        _opponentMoveType = (MoveType)randomeMove;
    }

    public void IncrementRoundNumber()
    {
        roundNumber++;
    }

    public void ResetMoves()
    {
        _opponentMoveType = MoveType.None;
        _playerMoveType = MoveType.None;
    }

    public bool IsRoundWon()
    {
        return MoveTypeTrumpsOverMoveTypeMapping[_playerMoveType].Contains(_opponentMoveType);
    }
}

public enum MoveType
{
    None,
    Rock,
    Paper,
    Scissors,
    Lizzard,
    Spock
}
