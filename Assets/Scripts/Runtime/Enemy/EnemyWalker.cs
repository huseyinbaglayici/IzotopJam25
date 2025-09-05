using Runtime.Player;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyWalker : EnemyBase
    {
        private float attackCooldown = 2f;
        private float lastAttackTime = 0f;

        protected void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    Attack();
                }
                else
                {
                    StopMoving();
                }
            }
            else
            {
                ChasePlayer();
                RotateTowardsPlayer();
            }
        }

        private void StopMoving()
        { 
            _rb.linearVelocity = Vector2.zero;
        }

        private void ChasePlayer()
        {
            if (_rb && player)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                _rb.linearVelocity = direction * moveSpeed;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Attack()
        {
            //spriteDirectionalController.animator.SetTrigger("Attack");
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Burada tekrar kontrol et ki oyuncu menzilden çıkmışsa vurmasın
            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                PlayerStatManager.Instance.DecreaseHealth(damage);
            }
        }

        private void RotateTowardsPlayer()
        {
            if (!player) return;

            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _rb.rotation = angle;
        }
    }
}