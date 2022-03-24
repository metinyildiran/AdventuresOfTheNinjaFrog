using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance { get; private set; }
    private UIHandler uiHandler;

    private int score;
    public int FinishedLevelIndex { get; private set; }

    public bool IsGameFinished { get; private set; }

    [Serializable]
    private class Data
    {
        public int _score;
        public int _finishedLevelIndex;
    }

    public void SaveData()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        var saveData = new Data
        {
            _score = score,
            _finishedLevelIndex = SceneManager.GetActiveScene().buildIndex
        };

        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }

    private void LoadSavedData()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<Data>(json);

            score = data._score;
            FinishedLevelIndex = data._finishedLevelIndex;
        }
        else
        {
            score = 0;
            FinishedLevelIndex = 0;
        }
    }

    public void ResetSavedData()
    {
        var path = Application.persistentDataPath + "/savefile.json";

        var saveData = new Data
        {
            _score = 0,
            _finishedLevelIndex = 0
        };

        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }
    
    public void FinishGame()
    {
        IsGameFinished = true;
    }

    private void Awake()
    {
        if (SharedInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        SharedInstance = this;
    }

    private IEnumerator Start()
    {
        uiHandler = GameObject.Find("UIHandler").GetComponent<UIHandler>();

        LoadSavedData();

        yield return new WaitForSeconds(0.1f);

        SetScore();
    }

    public void AddScore(int amount)
    {
        score += amount;
        SetScore();
    }

    private void SetScore()
    {
        uiHandler.SetScoreText(score);
    }
}