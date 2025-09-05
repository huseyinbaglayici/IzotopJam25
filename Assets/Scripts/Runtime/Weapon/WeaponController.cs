using Runtime.Extension;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Weapon
{
    public class WeaponController : MonoSingleton<WeaponController>
    {
        public Transform firePoint;
        public GameObject muzzleFlash;
        public GameObject bulletPrefab;
        [FormerlySerializedAs("firaRate")] public float fireRate;

        [Header("Weapon Stats")] protected bool isFiring = false;
        protected float lastFiredTime;


        public void Fire()
        {
            if (Time.time < lastFiredTime + fireRate)
                return;
            lastFiredTime = Time.time;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            // muzzle ile ilgili bir sey olacaksa burada efektler patlatilabilir ! 
        }
    }
}