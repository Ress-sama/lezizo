using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts
{
    public class InputProvider : MonoBehaviour
    {
        private InputSystem inputSystem;

        private void Awake()
        {
            inputSystem = new InputSystem();
            inputSystem.Player.Enable();
        }
    }
}