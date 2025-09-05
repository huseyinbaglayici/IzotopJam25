using Runtime.Player;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyBomber : EnemyBase
    {
        private float lastAttackTime = 0f;
        private float attackCooldown = 1f;
        [SerializeField] private bool bIsExploded;
        [SerializeField] private float explosionRadius = 2f;
        [SerializeField] private GameObject explosionEffectPrefab;
        [SerializeField] private bool canMove = true;



        public int bomberDamage = 2;
        public float bomberSpeed = 9f;


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
            if (bIsExploded)
            {
                Explode();
                return;
            }
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

        private void Explode()
        {
            if (explosionEffectPrefab != null)
            {
                Instantiate(explosionEffectPrefab,transform.position,Quaternion.identity);
            }

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            foreach (var hit in hitColliders)
            {
                if (hit.CompareTag("Player"))
                {
                    PlayerStatManager.Instance.DecreaseHealth(bomberDamage);
                }
            }
            base.Die();
        }
            
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
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
            if (!_rb || player == null || !canMove) return;

            Vector2 direction = (player.position - transform.position);
    
            float distanceX = direction.x;
            float distanceY = direction.y;

            float moveX = Mathf.Clamp(distanceX, -1f, 1f) * moveSpeed;
            float moveY = Mathf.Clamp(distanceY, -1f, 1f) * moveSpeed;
    
            _rb.linearVelocity = new Vector2(moveX, moveY);

        }

        protected override void Die()
        {
            base.Die();
            bIsExploded = true;
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