using System;
using Managers;
using Runtime.Extension;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Player
{
    public class PlayerController : MonoSingleton<PlayerController>
    {
        [Header("Movement Datas")] public int movementSpeed = 10;

        [FormerlySerializedAs("weponPivot")] [SerializeField]
        public Transform weaponPivot;

        [SerializeField] private bool bInputAvaible = true;
        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private Animator animator;


        private void Start()
        {
            if (rb == null)
                Debug.LogWarning("Rb has not been initialized");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void FixedUpdate()
        {
            Move();
            Aim();
        }

        public void TeleportToSpawnPoint(Vector2 spawnPoint)
        {
            StopMovement();
            transform.position = new Vector3(spawnPoint.x, spawnPoint.y, transform.position.z);
            StopMovement();
            Debug.Log("Player teleported");
        }

        public void StopMovement()
        {
            rb.linearVelocity = Vector2.zero;
        }

        public void Move()
        {
            if (!bInputAvaible) return;
            float2 movementInput = InputManager.Instance.GetMovementInputs();

            float normalizedX = Mathf.Abs(movementInput.x) < 0.1f ? 0f : Mathf.Sign(movementInput.x);
            float normalizedY = Mathf.Abs(movementInput.y) < 0.1f ? 0f : Mathf.Sign(movementInput.y);

            rb.linearVelocityX = movementInput.x * movementSpeed;
            rb.linearVelocityY = movementInput.y * movementSpeed;

            animator.SetFloat("horizontal", normalizedX);
            animator.SetFloat("vertical", normalizedY);
        }

        public void Aim()
        {
            Vector2 mouseWorldPosition = InputManager.Instance.GetMousePosition();
            Vector2 aimDir = (mouseWorldPosition - (Vector2)weaponPivot.position).normalized;

            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            weaponPivot.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}