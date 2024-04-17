// Set on GameObject with a ShadowCaster2D component
// Invoke GetShadowsPath to place the shapePath in the path array.

using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace AP.ShadowHelpers
{
    [RequireComponent(typeof(ShadowCaster2D))]
    public class ShadowPathGetter : MonoBehaviour
    {
        [SerializeField] private Vector3[] path;

        [ContextMenu("Get Shadows Path")]
        private void GetShadowsPath()
        {
            var shadowCaster2D = GetComponent<ShadowCaster2D>();
            if (shadowCaster2D == null) { return; }
            path = shadowCaster2D.shapePath;
        }
    }
}