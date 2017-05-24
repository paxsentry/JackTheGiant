using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{

    [SerializeField]
    private Text scoreText, coinScore;

    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    void SetScore(int score, int coins)
    {
        scoreText.text = score.ToString();
        coinScore.text = coins.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }

    public void ReturnMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
