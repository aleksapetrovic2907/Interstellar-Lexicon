using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace AP.ShadowHelpers
{
    public static class ShadowPathSetter
    {
        public static void SetShadowPath(ShadowCaster2D shadowCaster2D, Vector3[] path)
        {
            FieldInfo shapeField = typeof(ShadowCaster2D).GetField("m_ShapePath", BindingFlags.NonPublic | BindingFlags.Instance);
            shapeField.SetValue(shadowCaster2D, path);

            FieldInfo hashField = typeof(ShadowCaster2D).GetField("m_ShapePathHash", BindingFlags.NonPublic | BindingFlags.Instance);
            hashField.SetValue(shadowCaster2D, Random.Range(int.MinValue, int.MaxValue));
        }
    }
}