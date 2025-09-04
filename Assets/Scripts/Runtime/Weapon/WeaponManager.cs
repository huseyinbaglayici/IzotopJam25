using Managers;
using Runtime.Extension;

namespace Runtime.Weapon
{
    public class WeaponManager : MonoSingleton<WeaponManager>
    {
        public WeaponController weaponController;
        
        private void Update()
        {
            if (InputManager.Instance.IsLeftClick())
            {
                weaponController.Shoot();
            }
        }
    }
}