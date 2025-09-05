using System;
using System.Collections;
using Runtime.Managers;
using Unity.Cinemachine;
using UnityEngine;

namespace Runtime.Enviorement
{
    public class DoorTrigger : MonoBehaviour
    {
        public AudioSource doorSound;
        public float cameraSwitchDelay = 1f;
        public MapManager currentMap;
        public Animator doorAnimator;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Player") && currentMap.AllEnemiesDead())
            {
                //doorAnimator.SetTrigger("Open);
                Debug.LogWarning("kapiya temas");
                StartCoroutine(SwitchCameraAfterDelay());
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator SwitchCameraAfterDelay()
        {
            yield return new WaitForSeconds(cameraSwitchDelay);
            Debug.LogWarning("kamera degisti");
            CameraManager.Instance.SwitchToNextCamera();
        }
    }
}