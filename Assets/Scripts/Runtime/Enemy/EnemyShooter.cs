using System;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyShooter : EnemyBase
    {
        public GameObject projectilePrefab;
        public Transform firePoint;

        [Header("Attack Settings")] private float attackCooldown = 3f;
        private float bulletSpeed = 4f;
        [SerializeField] private float lastAttackTime = Mathf.NegativeInfinity;

        private void Update()
        {
            if (bIsDead) return;

            var distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

            if (distanceToPlayer <= attackRange)
            {
                LookAtPlayer();

                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
        }

        private void LookAtPlayer()
        {
            if (!player) return;

            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _rb.rotation = angle;
        }

        public override void Attack()
        {
            // sprite trigger
        }

        private void ShootBullet()
        {
            var bullet = Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = direction * bulletSpeed;
            }
        }
        
    }
}