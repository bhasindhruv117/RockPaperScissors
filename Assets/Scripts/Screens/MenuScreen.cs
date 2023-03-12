using TMPro;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    public void Initialize()
    {
        highScoreText.text = StatsManager.Instance.HighScore.ToString();
    }
    public void PlayButtonClicked()
    {
        GameStateMachine.RaiseGoToState(typeof(OpponentTurnState));
    }
}
