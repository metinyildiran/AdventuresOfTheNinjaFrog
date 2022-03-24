using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted;

    private LevelManager levelManager;

    private void Awake()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            GameManager.SharedInstance.FinishGame();
            
            finishSound.Play();

            levelCompleted = true;

            levelManager.Invoke(nameof(LevelManager.LoadNextLevel), 2f);
        }
    }
}