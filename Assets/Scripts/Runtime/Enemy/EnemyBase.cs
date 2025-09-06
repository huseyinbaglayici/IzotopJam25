using DG.Tweening;
using Runtime.Extension;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public bool isKnockedBack = false;
        private float knockbackTimer = 0f;
        private float knockbackDuration = 0.5f;


        public float moveSpeed = 5f;
        public float attackRange;
        public int damage = 1;
        public Transform player;
        protected Animator animator;
        protected const string stringPlayer = "Player";
        protected Rigidbody2D _rb;
        public bool bIsDead = false;

        public abstract void Attack();

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            if (isKnockedBack)
            {
                knockbackTimer -= Time.deltaTime;
                if (knockbackTimer <= 0)
                {
                    isKnockedBack = false;
                }

                return;
            }
        }

        public virtual void TakeDamage()
        {
            // Debug.LogWarning("Hit taken damage dealed");
            Die();
        }

        public void TakeKnockback(Vector2 direction, float force)
        {
            isKnockedBack = true;
            knockbackTimer = knockbackDuration;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }

        protected virtual void Die()
        {
            if (animator)
            {
                animator.SetBool("isDied", true);
            }

            _rb.linearVelocity = Vector2.zero;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            bIsDead = true;
            //animation codes oyun bittikten sonra polish ses vs
            _rb.linearVelocity = Vector2.zero; // öldüğünde dursun
            Destroy(transform.gameObject, 1.3f);
        }

        protected virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}