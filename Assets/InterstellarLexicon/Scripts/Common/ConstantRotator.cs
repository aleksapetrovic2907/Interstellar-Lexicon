using UnityEngine;

namespace AP
{
    public class ConstantRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 eulersPerFrame;

        private void LateUpdate() => transform.localEulerAngles += eulersPerFrame * Time.deltaTime;
    }
}