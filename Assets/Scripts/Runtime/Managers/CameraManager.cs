using System.Collections.Generic;
using Runtime.Extension;
using Unity.Cinemachine;
using UnityEngine;

namespace Runtime.Managers
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
        public List<CinemachineCamera> cameras;
        [SerializeField] private int currentIndex = 0;

        void Start()
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].Priority = (i == 0) ? 10 : 0;
            }
        }

        public void SwitchToNextCamera(float delay = 0f)
        {
            if (currentIndex + 1 >= cameras.Count) return;

            currentIndex++;
            if (delay > 0f)
                Invoke("SwitchToNextCamera", delay);
            else
                UpdateCameraPriority();
        }

        void UpdateCameraPriority()
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                cameras[i].Priority = (i == currentIndex) ? 10 : 0;
            }
        }
    }
}