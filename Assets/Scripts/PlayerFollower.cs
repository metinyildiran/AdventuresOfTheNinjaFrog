using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private bool alwaysFollow = true;
    [SerializeField] private float distanceX = 0;
    [SerializeField] private float distanceY = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (alwaysFollow)
        {
            FollowPlayer(player.transform.position.x,player.transform.position.y);
        }
        else if(player.transform.position.y + distanceY > transform.position.y)
        {
            FollowPlayer(transform.position.x, player.transform.position.y);
        }
    }
    private void FollowPlayer(float x, float y)
    {
        transform.position = new Vector3(x + distanceX, y + distanceY, transform.position.z);
    }
}
