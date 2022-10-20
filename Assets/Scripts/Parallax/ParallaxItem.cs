using System;
using UnityEngine;

namespace Parallax
{
    [Serializable]
    public class ParallaxItem
    {
        [SerializeField] private Transform itemTransform;
        [SerializeField] [Range(-4, 4)] private float ratio;


        public void UpdatePosition(Vector2 targetPos)
        {
            itemTransform.position = new Vector3(targetPos.x * ratio, itemTransform.position.y);
        }
    }
}