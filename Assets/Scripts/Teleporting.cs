using UnityEngine;

public class Teleporting : MonoBehaviour
{
    [SerializeField] private GameObject teleportingLocationObject;
    private Vector2 teleportingLocation;

    private void Start()
    {
        teleportingLocation = teleportingLocationObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = teleportingLocation;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = teleportingLocation;
        }
    }
}