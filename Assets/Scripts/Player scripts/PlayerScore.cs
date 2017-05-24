using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;
    private bool countScore;
    private Vector3 previousPostion;

    public static int scoreCount, lifeCount, coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    void Start()
    {
        previousPostion = transform.position;
        countScore = true;
    }

    void Update()
    {
        CountScore();
    }

    private void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPostion.y)
            {
                scoreCount++;
            }
            previousPostion = transform.position;
            GameplayController.instance.SetScore(scoreCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        int multiply = 1;
        if (GamePreferences.GetMediumDifficulty() == 1)
            multiply = 2;

        if (GamePreferences.GetHardDifficulty() == 1)
            multiply = 3;

        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200 * multiply;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300 * multiply;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            lifeCount--;
            transform.position = new Vector3(500, 500, 0);
            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
    }
}