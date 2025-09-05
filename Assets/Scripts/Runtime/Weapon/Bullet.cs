using UnityEngine;

namespace Runtime.Weapon
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed = 10;
        private const string Enemy = "Enemy";

        [SerializeField] private Rigidbody2D rb;

        private void Start()
        {
            rb.linearVelocity = transform.right * bulletSpeed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            HandleHit(other);
        }

        private void HandleHit(Collision2D hit)
        {
            if (!hit.transform.CompareTag("Enemy") || hit.transform.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            else
            {
                var enemyBase = hit.transform.GetComponent<Enemy.EnemyBase>();
                if (enemyBase != null)
                {
                    enemyBase.TakeDamage();
                }

                Destroy(gameObject);
            }
        }
    }
}