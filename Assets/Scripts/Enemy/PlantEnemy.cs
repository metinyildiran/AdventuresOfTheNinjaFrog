using UnityEngine;

namespace Enemy
{
    public class PlantEnemy : EnemyBase
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private bool alwaysShooting;
        private readonly Vector3 bulletOffset = new Vector3(0.9f, 0.2f, 0);

        protected override void Update()
        {
            base.Update();
            
            if (alwaysShooting)
            {
                PlantShooting(alwaysShooting);
            }
        }

        protected override void OnPlayerSight()
        {
            PlantShooting(true);
        }

        protected override void OnPlayerOutOfSight()
        {
            PlantShooting(false);
        }

        protected override void OnPlayerDead()
        {
            PlantShooting(false);
        }

        private void PlantShooting(bool shooting)
        {
            var anim = gameObject.GetComponent<Animator>();
            anim.SetBool("attacking", shooting);
        }

        public void CreateBullet()
        {
            Instantiate(bullet, transform.position + bulletOffset, transform.rotation, transform);
        }
    }
}