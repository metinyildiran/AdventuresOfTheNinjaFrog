using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLastLevel();
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
        GameManager.SharedInstance.ResetSavedData();

        SceneManager.LoadScene(1);
    }

    public void HideWarningPrompt()
    {
        warningPrompt.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
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