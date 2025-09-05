using System;
using Runtime.Extension;
using UnityEngine;

namespace Runtime.Managers
{
    public class BulletTimeManager : MonoSingleton<BulletTimeManager>
    {
        [Header("Bullet Time Manager")]
        public float slowTimeScale = 0.2f;
        public float duration = 2f;
        public float transitionSpeed = 5f;

        private float normalTimeScale = 1f;
        private float timer;
        private bool isBulletTime;


        private void Update()
        {
            if (isBulletTime)
            {
                timer -= Time.unscaledTime;
                if (timer <= 0f)
                {
                    EndBulletTime();
                }
            }
            
            //Smooth switch
            Time.timeScale = Mathf.Lerp(Time.timeScale,isBulletTime ? slowTimeScale : normalTimeScale,
                Time.unscaledDeltaTime * transitionSpeed);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        public void StartBulletTime()
        {
            isBulletTime = true;
            timer = duration;
        }

        private void EndBulletTime()
        {
            isBulletTime = false;
            Debug.LogWarning("bullet time finished succesfuly");
        }
    }
}