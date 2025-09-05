using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyShooter : EnemyBase
    {
        public GameObject projectilePrefab;
        public Transform firePoint;

        [SerializeField] private Transform spriteTransform;


        [Header("Attack Settings")] private float attackCooldown = 3f;
        [SerializeField] private float bulletSpeed = 11f;
        [SerializeField] private float lastAttackTime = Mathf.NegativeInfinity;

        private void Update()
        {
            if (bIsDead) return;

            var distanceToPlayer = Vector2.Distance(player.position, transform.position);

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
            Vector2 direction = (player.position - transform.position).normalized;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float currentAngle = spriteTransform.eulerAngles.z;
            float smoothAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * 5f);

            if (spriteTransform)
            {
                spriteTransform.rotation = Quaternion.Euler(0, 0, smoothAngle);
            }

            if (firePoint)
            {
                firePoint.rotation = spriteTransform.rotation;
            }
        }

        public override void Attack()
        {
            // sprite trigger
            ShootBullet();
        }

        private void ShootBullet()
        {
            var bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = firePoint.right;
                rb.linearVelocity = direction * bulletSpeed;
            }
        }
    }
}