using UnityEngine;

public class StatsManager
{
    #region SINGLETON

    private static StatsManager _instance;

    public static StatsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StatsManager();
                _instance.Initialize();
            }
            return _instance;
        }
    }

    private void Initialize()
    {
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    #endregion
    
    private int highScore;

    public int HighScore => highScore;

    public void CheckAndUpdateHighScore(int newScore)
    {
        if (newScore > highScore) {
            highScore = newScore;
            PlayerPrefs.SetInt("HighScore",highScore);
            PlayerPrefs.Save();
        }
    }
}
