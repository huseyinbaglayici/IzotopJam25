using Runtime.Extension;
using Unity.Mathematics;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public float2 GetMovementInputs()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            return new float2(x, y);
        }

        public bool IsLeftClick()
        {
            return Input.GetMouseButtonDown(0);
        }

        public Vector2 GetMousePosition()
        {
            var mainCam = Camera.main;
            var mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(mainCam.transform.position.z);
            return mainCam.ScreenToWorldPoint(mousePosition);
        }

        public bool IsRKeyPressed()
        {
            return Input.GetKeyDown(KeyCode.R);
        }
        
        public bool IsVKeyPressed()
        {
            return Input.GetKeyDown(KeyCode.V);
        }
    }
}