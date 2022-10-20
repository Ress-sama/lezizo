using System.Collections.Generic;
using UnityEngine;

namespace Parallax
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private List<ParallaxItem> parallaxItems;
        [SerializeField] private Camera camera;


        private void UpdateParallax()
        {
            foreach (var parallaxItem in parallaxItems)
            {
                parallaxItem.UpdatePosition(camera.transform.position);
            }
        }

        private void Update()
        {
            UpdateParallax();
        }
    }
}