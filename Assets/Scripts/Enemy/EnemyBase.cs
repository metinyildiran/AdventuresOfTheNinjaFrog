using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        protected GameObject Player;

        protected virtual void Start()
        {
            Player = GameObject.FindWithTag("Player");
        }

        protected virtual void Update()
        {
            var isPlayerAlive = !GameManager.SharedInstance.IsGameFinished;
            if (isPlayerAlive)
            {
                if (RaycastPlayer())
                {
                    OnPlayerSight();
                }
                else
                {
                    OnPlayerOutOfSight();
                }
            }
            else
            {
                OnPlayerDead();
            }
        }

        private bool RaycastPlayer()
        {
            var raycastHit2D = Physics2D.Raycast(transform.position, -transform.right * 35);

            return raycastHit2D.collider != null && raycastHit2D.collider.gameObject.CompareTag("Player");
        }

        protected abstract void OnPlayerSight();

        protected abstract void OnPlayerOutOfSight();

        protected abstract void OnPlayerDead();
    }
}