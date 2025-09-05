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

        public void Move()
        {
            if (!bInputAvaible) return;
            float2 movementInput = InputManager.Instance.GetMovementInputs();

            Debug.Log(movementInput);
            rb.linearVelocityX = movementInput.x * movementSpeed;
            rb.linearVelocityY = movementInput.y * movementSpeed;

            animator.SetFloat("horizontal", movementInput.x);
            animator.SetFloat("vertical", movementInput.y);
        }

        public void Aim()
        {
            Vector2 mouseWorldPosition = InputManager.Instance.GetMousePosition();
            Vector2 aimDir = (mouseWorldPosition - (Vector2)weaponPivot.position).normalized;

            float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            weaponPivot.rotation = Quaternion.Euler(0, 0, angle);
        }

        public float GetrbVelocity()
        {
            return rb.linearVelocity.magnitude;
        }
    }
}