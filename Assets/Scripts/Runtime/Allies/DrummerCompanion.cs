using Managers;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Allies
{
    public class DrummerCompanion : CompanionBase
    {
        [SerializeField] private AudioClip DrummerSound;
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

                BulletTimeManager.Instance.StartBulletTime();
                AudioManager.Instance.PlayMusic(AudioManager.Instance.bassGuiltarSkill);
                StartCooldown();
            }
        }
    }
}