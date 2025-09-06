        using DG.Tweening;
        using Managers;
        using Runtime.Managers;
        using UnityEngine;
        using UnityEngine.Serialization;

        namespace Runtime.Allies
        {
            public class BasistCompanion : CompanionBase
            {

                public Transform FirePoint;
                [FormerlySerializedAs("basistProjectile")] public GameObject basistProjectilePrefab;


                protected override void Start()
                {
                    base.Start();
                }

                protected override void UseAbility()
                {
                    if (CanAbilityUsable() && InputManager.Instance.IsRKeyPressed())
                    {
                        //audioMan
                        if(FirePoint == null|| basistProjectilePrefab == null) return;
                        
                        var basProjectile = Instantiate(basistProjectilePrefab,FirePoint.position, FirePoint.rotation);
                        BasistProjectile bassAttack = basProjectile.GetComponent<BasistProjectile>();
                        if (bassAttack != null)
                        {
                            //aud man
                            // efekt
                            // dotween belki
                        }
                        Debug.LogWarning("Basist vurdu");
                        AudioManager.Instance.PlayMusic(AudioManager.Instance.bassGuiltarSkill);
                        StartCooldown();
                    }
                }
            }
        }