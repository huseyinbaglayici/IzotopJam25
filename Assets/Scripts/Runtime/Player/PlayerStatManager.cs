using Runtime.Extension;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerStatManager : MonoSingleton<PlayerStatManager>
    {
        public int health =3;
        public int maxHealth =3;


        public void DecreaseHealth(int amount)
        {
            Debug.LogWarning(health);
            health = Mathf.Max(health - amount, 0);
            //UIManager
            if (health == 0)
            {
                Debug.LogWarning("Player is dead");
            }
        }
    }
}