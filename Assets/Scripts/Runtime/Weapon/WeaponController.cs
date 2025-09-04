using Runtime.Extension;
using UnityEngine;

namespace Runtime.Weapon
{
    public class WeaponController : MonoSingleton<WeaponController>
    {
        public Transform firePoint;
        public GameObject muzzleFlash;
        public GameObject bulletPrefab;

        [Header("Weapon Stats")] 
        protected bool isFiring = false;
        protected float lastFiredTime;


        public void Shoot()
        {
            Debug.LogWarning("Shoot");
        }
    }
}