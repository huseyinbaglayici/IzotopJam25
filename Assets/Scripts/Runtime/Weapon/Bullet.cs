using System;
using UnityEngine;

namespace Runtime.Weapon
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed;

        private const string enemy = "Enemy";
        
        [SerializeField] private Rigidbody2D rb;


        private void Start()
        {
            rb.linearVelocity = transform.right * bulletSpeed;
        }

        // private void OnCollisionEnter2D(Collision2D collision)
        // {
        //     if (collision.transform.tag == enemy)
        //     {
        //         // enemy codes
        //     }
        //     
        //     Destroy(gameObject);
        // }

        private void OnCollisionEnter2D(Collision2D other)
        {
            HandleHit(other);
        }

        private void HandleHit(Collision2D hit)
        {
            if (!hit.transform.CompareTag(enemy))
            {
                Destroy(gameObject);
            }
            else
            {
                //dusmana hasar verme logic eklencek
            }
        }
    }
}