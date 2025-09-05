using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Allies
{
    public abstract class CompanionBase : MonoBehaviour
    {
        [Header("Follow Settings")] public float moveSpeed = 5f;
        public float followDistance = 2f;
        public Vector2 offset;
        public float randomMovement = 0.3f;

        [Header("Ability Settings")] public float abilityCooldown = 3f;
        protected float cooldownTimer = 0f;

        protected Transform player;
        private Vector2 noiseOffset;
        public bool bAbilityUsable;

        protected virtual void Awake()
        {
            noiseOffset = new Vector2(Random.Range(0f, 100f), Random.Range(0f, 100f));
        }

        protected virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player == null)
            {
                Debug.LogWarning(gameObject.name + ": No player assigned.");
                return;
            }
        }

        protected virtual void Update()
        {
            if (player == null) return;

            HandleMovement();
            UpdateCooldown();
            HandleAbility();
        }

        private void HandleMovement()
        {
            Vector3 targetPosition = player.position + (Vector3)offset;

            // Random hareket ekle
            float randomX = (Mathf.PerlinNoise(Time.time + noiseOffset.x, 0f) - 0.5f) * randomMovement;
            float randomY = (Mathf.PerlinNoise(0f, Time.time + noiseOffset.y) - 0.5f) * randomMovement;
            Vector2 randomOffset = new Vector2(randomX, randomY);

            Vector3 finalTarget = targetPosition + (Vector3)randomOffset;

            if (Vector2.Distance(transform.position, targetPosition) > followDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    finalTarget,
                    moveSpeed * Time.deltaTime
                );
            }
        }
        
        private void UpdateCooldown()
        {
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.deltaTime;
                bAbilityUsable = false;
            }
            else
            {
                bAbilityUsable = true;
            }
        }

        private void HandleAbility()
        {
            if (CanAbilityUsable())
            {
                UseAbility();
            }
        }

        public bool CanAbilityUsable()
        {
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.deltaTime;
                bAbilityUsable = false;
            }
            else if (cooldownTimer <= 0f)
            {
                bAbilityUsable = true;
            }

            return bAbilityUsable;
        }

        protected abstract void UseAbility();
    }
}