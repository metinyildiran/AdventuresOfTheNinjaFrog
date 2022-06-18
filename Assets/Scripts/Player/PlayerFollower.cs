using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private bool alwaysFollow = true;

    private GameObject player;

    private float distanceX = 0;
    private float distanceY = 0;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (alwaysFollow)
        {
            FollowPlayer(player.transform.position.x, player.transform.position.y);
        }
        else if (player.transform.position.y + distanceY > transform.position.y)
        {
            FollowPlayer(transform.position.x, player.transform.position.y);
        }
    }

    private void FollowPlayer(float x, float y)
    {
        transform.position = new Vector3(x + distanceX, y + distanceY, transform.position.z);
    }
}
