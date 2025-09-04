using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Enemy
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack,
        Dead
    }

    public abstract class EnemyBase : MonoBehaviour
    {
        [Header("Stats")] public bool isDead = false;
        public float moveSpeed = 3.5f;
        public int attackRange = 10;
        public int damage;
        public Transform player;
        public EnemyState currentState = EnemyState.Idle;

        public abstract void Attack();

        public virtual void TakeDamage()
        {
            if (isDead) return;

            Die();
        }

        private void Die()
        {
            isDead = true;
        }

        protected virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected virtual void Update()
        {
            if (isDead) return;

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                currentState = EnemyState.Attack;
            }

            else
            {
                currentState = EnemyState.Chase;
            }
        }
        
        private void FixedUpdate()
        {
            if (currentState == EnemyState.Chase)
            {
                Vector2 dir = (player.position - transform.position).normalized;
                // rb.MovePosition(rb.position + dir * chaseSpeed * Time.fixedDeltaTime);
            }
        }
    }
}