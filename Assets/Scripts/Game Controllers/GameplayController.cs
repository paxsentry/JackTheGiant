using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, finalScore, finalCoins;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private Button readyButton;

    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // To play the animation in the main menu
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coin)
    {
        coinText.text = "x" + coin.ToString();
    }

    public void SetLifeScore(int life)
    {
        lifeText.text = "x" + life.ToString();
    }

    public void GameOverShowPanel(int score, int coins)
    {
        gameOverPanel.SetActive(true);
        finalScore.text = score.ToString();
        finalCoins.text = coins.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return StartCoroutine(TimeHandler.WaitForRealTimeSeconds(3f));
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return StartCoroutine(TimeHandler.WaitForRealTimeSeconds(1f));
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartTheGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}