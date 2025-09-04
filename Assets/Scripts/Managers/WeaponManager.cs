using Runtime.Extension;

namespace Managers
{
    public class WeaponManager : MonoSingleton<WeaponManager>
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