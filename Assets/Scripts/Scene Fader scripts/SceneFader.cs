using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

    private void Awake()
    {
        MakeSingleton();
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

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);

        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(TimeHandler.WaitForRealTimeSeconds(1f));

        SceneManager.LoadScene(level);

        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(TimeHandler.WaitForRealTimeSeconds(.7f));

        fadePanel.SetActive(false);
    }
}
