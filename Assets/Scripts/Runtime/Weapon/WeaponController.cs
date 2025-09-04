using Managers;
using Runtime.Extension;

namespace Runtime.Weapon
{
    public class WeaponController : MonoSingleton<WeaponController>
    {
        private void Update()
        {   
            if (InputManager.Instance.IsLeftClick())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            
        }
    }
}