using Runtime.Player;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyBomber : EnemyBase
    {
        private float lastAttackTime = 0f;
        private float attackCooldown = 1f;
        [SerializeField] private bool bIsExploded;


        public int bomberDamage;
        public float bomberSpeed = 15f;


        protected override void Start()
        {
            InitProperties();
        }

        private void InitProperties()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            moveSpeed = bomberSpeed;
            damage = bomberDamage;
        }

        protected override void Update()
        {
            base.Update();
            if (isKnockedBack) return;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
            }
            else
            {
                ChasePlayer();
                RotateTowardsPlayer();
            }
        }

        private void RotateTowardsPlayer()
        {
            if (!player) return;

            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _rb.rotation = angle;
        }

        private void ChasePlayer()
        {
            if (_rb && player)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                _rb.linearVelocity = direction * moveSpeed;
            }
        }

        protected override void Die()
        {
            base.Die();
            bIsExploded = true;
        }

        private void StopMoving()
        {
            _rb.linearVelocity = Vector2.zero;
        }

        public override void Attack()
        {
            //spriteDirectionalController.animator.SetTrigger("Attack");
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Burada tekrar kontrol et ki oyuncu menzilden çıkmışsa vurmasın
            if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                bIsExploded = true;
                PlayerStatManager.Instance.DecreaseHealth(damage);
            }
        }
    }
}