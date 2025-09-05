// DoorTrigger.cs
using System.Collections;
using Runtime.Managers;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Environment
{
    public class DoorTrigger : MonoBehaviour
    {
        public float cameraSwitchDelay = 1f;
        public MapManager currentMap;
        public Transform nextMapSpawnPoint;
        public Animator doorAnimator;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && currentMap.AllEnemiesDead())
            {
                StartCoroutine(CameraSwitchAndTeleport());
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator CameraSwitchAndTeleport()
        {
            yield return new WaitForSeconds(cameraSwitchDelay);

            CameraManager.Instance.SwitchToNextCamera();

            if (nextMapSpawnPoint != null)
            {
                PlayerController.Instance.TeleportToSpawnPoint(nextMapSpawnPoint.position);
            }
        }
    }
}