using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AP.UI
{
    public class InsertionPointBehaviour : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float duration;

        private void Start() => StartCoroutine(IPBlinkCoroutine());

        private IEnumerator IPBlinkCoroutine()
        {
            yield return new WaitForSeconds(duration);
            image.enabled = !image.enabled;
            StartCoroutine(IPBlinkCoroutine());
        }
    }
}