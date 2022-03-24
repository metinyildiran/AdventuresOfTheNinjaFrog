using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float impulseSpeed = 15;
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SetIsJumping(true);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * impulseSpeed;
        audioSource.Play();
    }

    public void ReturnBackToIdle()
    {
        SetIsJumping(false);
    }

    private void SetIsJumping(bool isJumping)
    {
        animator.SetBool("IsJumping", isJumping);
    }
}