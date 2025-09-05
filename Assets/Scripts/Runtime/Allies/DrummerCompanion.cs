using Managers;
using UnityEngine;

namespace Runtime.Allies
{
    public class DrummerCompanion : CompanionBase
    {
        public Transform FirePoint;

        protected override void Start()
        {
            base.Start();
        }

        protected override void UseAbility()
        {
            if (CanAbilityUsable() && InputManager.Instance.IsVKeyPressed())
            {
             Debug.LogWarning("DrummerCompanion");   
                
                StartCooldown();
            }
        }
    }
}