using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLastLevel()
    {
        SceneManager.LoadScene(GameManager.SharedInstance.FinishedLevelIndex + 1);
    }

    public void LoadNextLevel()
    {
        GameManager.SharedInstance.SaveData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}