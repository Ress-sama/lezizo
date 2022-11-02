using Riyezu.Player.StateMachine.Abilities;
using UnityEngine;

namespace Riyezu.Player
{
    public class TurnManager
    {
        private float lastMoveValue;
        private Rigidbody2D rigidbody2D;

        public TurnManager(Rigidbody2D rigidbody2D)
        {
            this.rigidbody2D = rigidbody2D;
        }


        public void Turn(float value)
        {
            if (value > 0)
            {
                TurnRight();
            }
            else if (value < 0)
            {
                TurnLeft();
            }
            if (lastMoveValue <= value)
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            }
        }

        private void TurnLeft()
        {
            rigidbody2D.transform.rotation =
                Quaternion.Euler(0, 180, 0);
        }

        private void TurnRight()
        {
            rigidbody2D.transform.rotation =
                Quaternion.Euler(0, 0, 0);
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }
}