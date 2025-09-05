using System;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyProjectile : MonoBehaviour
    {
        public int damage = 1;
        private const string Player = "Player";

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Player))
            {
                PlayerStatManager.Instance.DecreaseHealth(1);
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }
}