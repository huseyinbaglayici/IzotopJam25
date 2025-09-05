using UnityEngine;

namespace Runtime.Extension
{
    public class SpriteStatesController : MonoSingleton<SpriteStatesController>
    {
        public Animator animator;
        public Transform characterTransform;

        private Vector2 lastPosition;
        private void Start()
        {
            lastPosition = transform.position;
        }
    }
}