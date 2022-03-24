using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRigidbody;
    private Bullet bullet;
    private int bulletSpeed = 20;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bullet = gameObject.GetComponent<Bullet>();
    }

    private void Start()
    {
        MakeBulletMove();
    }
    
    private void MakeBulletMove()
    {
        var parentY = transform.parent.rotation.eulerAngles.y;
        if (parentY == 180)
        {
            bullet.SetBulletSpeed(bulletSpeed);
        }
        else if (parentY == 0)
        {
            bullet.SetBulletSpeed(-bulletSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void SetBulletSpeed(float speed)
    {
        bulletRigidbody.velocity = new Vector2(speed, 0);
    }
}