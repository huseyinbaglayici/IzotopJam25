using Runtime.Enemy;
using UnityEngine;

namespace Runtime.Allies
{
    public class BasistProjectile : MonoBehaviour
    {
        public float Speed = 20f;
        public float LifeTime = 3.5f; 
        public float knockBackForce = 15f;

        [SerializeField] private Rigidbody2D rb;


        protected virtual void Start()
        {
            rb.linearVelocity = transform.right * Speed;
            Destroy(gameObject, LifeTime);
        }

        // private void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (other.gameObject.CompareTag("Enemy"))
        //     {
        //         var enemyBase = other.gameObject.GetComponent<EnemyBase>();
        //         if (enemyBase != null)
        //         {
        //             Vector2 knockbackDir = (other.transform.position - transform.position).normalized;
        //             
        //             enemyBase.TakeKnockback(knockbackDir,knockbackForce);
        //         }
        //         Destroy(gameObject);
        //     }
        // }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log("COLLISION OLDU: " + other.gameObject.name + " - TAG: " + other.gameObject.tag);
    
            if (other.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log("ENEMY DOĞRULANDI!");
        
                var enemyBase = other.gameObject.GetComponent<Enemy.EnemyBase>();
                if (enemyBase != null)
                {
                    //Debug.Log("ENEMYBASE BULUNDU!");
                    Vector2 knockbackDir = (other.transform.position - transform.position).normalized;
                    enemyBase.TakeKnockback(knockbackDir, knockBackForce);
                    //Debug.Log("KNOCKBACK VE DAMAGE UYGULANDDI!");
                }
                else
                {
                    // Debug.Log("ENEMYBASE COMPONENT YOK!");
                }
            }
            else
            {
                //Debug.Log("TAG ENEMY DEĞİL: " + other.gameObject.tag);
            }
    
            Destroy(gameObject);
        }

    }
}