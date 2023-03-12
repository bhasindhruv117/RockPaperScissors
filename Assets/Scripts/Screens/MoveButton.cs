using UnityEngine;

public class MoveButton : MonoBehaviour
{
    [SerializeField] private MoveType _moveType;

    public void ButtonClicked()
    {
        GameScreen.RaiseOnTurnPlayed(_moveType);
    }
}
