using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private LevelManager levelManager;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        
        playerAnimator.SetTrigger("death");
        
        playerRigidbody.bodyType = RigidbodyType2D.Static;
        
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        
        GameManager.SharedInstance.FinishGame();
    }
    
    private void RestartLevel()
    {
        levelManager.RestartLevel();
    }
}