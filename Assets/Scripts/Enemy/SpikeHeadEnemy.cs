using UnityEngine;

namespace Enemy
{
    public class SpikeHeadEnemy : EnemyBase
    {
        protected override void OnPlayerSight()
        {
            FollowPlayer(true);
        }

        protected override void OnPlayerOutOfSight()
        {
            FollowPlayer(false);
        }

        protected override void OnPlayerDead()
        {
            FollowPlayer(false);
        }

        private void FollowPlayer(bool isFollowing)
        {
            if (isFollowing || GameManager.SharedInstance.IsGameFinished) return;

            if (!(Mathf.Abs(Player.transform.position.y - transform.position.y) < 1)) return;

            var transformPosition = transform.position;
            transformPosition.x = Vector2.MoveTowards(transformPosition, Player.transform.position,
                Time.deltaTime * 3).x;
            transform.position = transformPosition;
        }
    }
}