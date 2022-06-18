using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance { get; private set; }

    public int FinishedLevelIndex { get; private set; }

    public bool IsGameFinished { get; private set; }

    private int score;

    public Action<int> OnAddScore;

    private void Awake()
    {
        SharedInstance = this;
    }

    private IEnumerator Start()
    {
        LoadSavedData();

        yield return new WaitForSeconds(0.1f);

        AddScore(0);
    }

    public void AddScore(int amount)
    {
        score += amount;

        OnAddScore?.Invoke(score);
    }

    public void ResumeGame()
    {
        FindObjectOfType<LevelManager>().LoadLastLevel();
    }

    public void FinishGame()
    {
        IsGameFinished = true;
    }

    public void StartANewGame()
    {
        ResetSavedData();

        SceneManager.LoadScene(1);
    }

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
}