using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private Text scoreText;
    [SerializeField] private GameObject warningPrompt;

    private void Start()
    {
        if (!IsThisSceneMainMenu())
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        EnableResumeButton();

        GameManager.SharedInstance.OnAddScore += SetScoreText;
    }

    private void EnableResumeButton()
    {
        if (IsThisGamePlayedBefore() && IsThisSceneMainMenu())
        {
            GameObject.Find("ResumeButton").GetComponent<Button>().interactable = true;
        }
    }

    public void SetScoreText(int score)
    {
        if (scoreText)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    public void ResumeGame()
    {
        GameManager.SharedInstance.ResumeGame();
    }

    public void StartGame()
    {
        if (IsThisGamePlayedBefore() && warningPrompt)
        {
            warningPrompt.SetActive(true);
        }
        else
        {
            StartANewGame();
        }
    }

    public void StartANewGame()
    {
        GameManager.SharedInstance.StartANewGame();
    }

    public void HideWarningPrompt()
    {
        warningPrompt.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        GameManager.SharedInstance.OnAddScore += SetScoreText;
    }

    private bool IsThisGamePlayedBefore()
    {
        return GameManager.SharedInstance.FinishedLevelIndex != 0 && GameManager.SharedInstance.FinishedLevelIndex !=
            SceneManager.sceneCountInBuildSettings - 2;
    }

    private bool IsThisSceneMainMenu()
    {
        return SceneManager.GetActiveScene().buildIndex == 0;
    }
}