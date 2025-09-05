using System;
using Runtime.Extension;
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
        public float moveSpeed = 5f;
        public float attackRange;   
        public int damage = 1;
        public Transform player;
        //public EnemyState currentState = EnemyState.Idle;
        public SpriteStatesController spriteDirectionalController;
        protected const string stringPlayer =  "Player";
        protected Rigidbody2D _rb;
        protected bool bIsDead = false;


        public abstract void Attack();

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public virtual void TakeDamage()
        {
            Debug.LogWarning("Hit taken damage dealed");
            Die();
        }

        protected void Die()
        {
            bIsDead = true;
            //animation codes oyun bittikten sonra polish ses vs
            _rb.linearVelocity = Vector2.zero; // öldüğünde dursun
            Destroy(transform.gameObject,1.3f);
  
        }

        protected virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }
}