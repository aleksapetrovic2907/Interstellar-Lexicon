using UnityEngine;

namespace AP
{
    public static class VectorExtensions
    {
        public static float GetRandomInRange(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }
    }
}