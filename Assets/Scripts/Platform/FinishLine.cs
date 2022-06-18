using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private AudioSource finishSound;
    private LevelManager levelManager;

    private bool levelCompleted;

    private void Awake()
    {
        finishSound = GetComponent<AudioSource>();

        levelManager = FindObjectOfType<LevelManager>();
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