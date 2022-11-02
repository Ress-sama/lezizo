using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PlayEatRepeat.Player
{
    public class InputProvider : MonoBehaviour
    {
        private InputSystem inputSystem;

        private void Awake()
        {
            inputSystem = new InputSystem();
            ;
        }
    }
}