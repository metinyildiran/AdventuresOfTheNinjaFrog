using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // private LevelFinishedAd levelFinishedAd;
    //
    // private void Start()
    // {
    //     levelFinishedAd = GameObject.Find("AdManager").GetComponent<LevelFinishedAd>();
    // }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(GameManager.SharedInstance.FinishedLevelIndex + 1);
    }
    
    public void LoadNextLevel()
    {
        GameManager.SharedInstance.SaveData();
        
        // levelFinishedAd.ShowAd();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}