using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        GameStateMachine.RaiseGoToState(typeof(OpponentTurnState));
    }
}
