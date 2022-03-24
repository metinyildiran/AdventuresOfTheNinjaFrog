using UnityEngine;

namespace Enemy
{
    public class RinoEnemy : EnemyBase
    {
        private Animator animator;
        private float speed = 3;

        protected override void Start()
        {
            base.Start();

            animator = gameObject.GetComponent<Animator>();
        }

        protected override void OnPlayerSight()
        {
            Run(true);
        }

        protected override void OnPlayerOutOfSight()
        {
            Run(false);
        }

        protected override void OnPlayerDead()
        {
            Run(false);
        }

        private void Run(bool isRunning)
        {
            SetRunAnimation(isRunning);

            if (isRunning)
            {
                var transformPosition = transform.position;
                transformPosition.x = Vector2.MoveTowards(transformPosition, Player.transform.position,
                    Time.deltaTime * speed).x;
                transform.position = transformPosition;

                speed += 1.6f * Time.deltaTime;
            }
        }

        private void SetRunAnimation(bool isRunning)
        {
            animator.SetBool("IsRunning", isRunning);
        }
    }
}