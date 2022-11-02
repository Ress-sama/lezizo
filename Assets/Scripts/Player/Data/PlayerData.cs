using UnityEngine;

namespace PlayEatRepeat.Player.Data
{
    [CreateAssetMenu(fileName = "new PlayerData", menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float MoveSpeed;
    }
}