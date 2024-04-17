using System.Collections.Generic;
using UnityEngine;

namespace AP.UI
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> backgrounds;
        [SerializeField] private float speed;


        private void Update()
        {
            CheckForSwap();
            MoveBackgrounds();
        }

        private void CheckForSwap()
        {
            var firstBackground = backgrounds[0];
            bool hasFirstLeftScreen = firstBackground.transform.position.x <= -firstBackground.size.x;

            if (hasFirstLeftScreen)
            {
                backgrounds.RemoveAt(0);
                backgrounds.Add(firstBackground);
                firstBackground.transform.position = (backgrounds.Count - 1) * firstBackground.size.x * Vector2.right;
            }
        }

        private void MoveBackgrounds()
        {
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgrounds[i].transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}