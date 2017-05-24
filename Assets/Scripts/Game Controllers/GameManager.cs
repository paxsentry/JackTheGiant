using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDeath;

    [HideInInspector]
    public int score, coins, life;

    void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        InitialiseVariables();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    private void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            if (gameRestartedAfterPlayerDeath)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coins);
                GameplayController.instance.SetLifeScore(life);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coins;
                PlayerScore.lifeCount = life;
            }
            else if (gameStartedFromMainMenu)
            {
                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);

                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;
            }
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int scr, int cns, int lf)
    {
        if (lf < 0)
        {
            if (GamePreferences.GetEasyDifficulty() == 1)
            {
                int currentScore = GamePreferences.GetEasyDifficultyHighScore();
                int currentCoins = GamePreferences.GetEasyDifficultyCoinScore();

                if (currentScore < scr)
                    GamePreferences.SetEasyDifficultyHighScore(scr);
                if (currentCoins < cns)
                    GamePreferences.SetEasyDifficultyCoinScore(cns);
            }

            if (GamePreferences.GetMediumDifficulty() == 1)
            {
                int currentScore = GamePreferences.GetMediumDifficultyHighScore();
                int currentCoins = GamePreferences.GetMediumDifficultyCoinScore();

                if (currentScore < scr)
                    GamePreferences.SetMediumDifficultyHighScore(scr);
                if (currentCoins < cns)
                    GamePreferences.SetMediumDifficultyCoinScore(cns);
            }

            if (GamePreferences.GetHardDifficulty() == 1)
            {
                int currentScore = GamePreferences.GetHardDifficultyHighScore();
                int currentCoins = GamePreferences.GetHardDifficultyCoinScore();

                if (currentScore < scr)
                    GamePreferences.SetHardDifficultyHighScore(scr);
                if (currentCoins < cns)
                    GamePreferences.SetHardDifficultyCoinScore(cns);
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDeath = false;

            GameplayController.instance.GameOverShowPanel(scr, cns);
        }
        else
        {
            score = scr;
            coins = cns;
            life = lf;

            GameplayController.instance.SetScore(score);
            GameplayController.instance.SetCoinScore(coins);
            GameplayController.instance.SetLifeScore(life);

            gameRestartedAfterPlayerDeath = true;
            gameStartedFromMainMenu = false;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }

    void InitialiseVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialised"))
        {
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetEasyDifficultyHighScore(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);

            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyHighScore(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyHighScore(0);
            GamePreferences.SetHardDifficultyCoinScore(0);

            GamePreferences.SetIsMusicOn(0);

            PlayerPrefs.SetInt("Game Initialised", 1);
        }
    }
}