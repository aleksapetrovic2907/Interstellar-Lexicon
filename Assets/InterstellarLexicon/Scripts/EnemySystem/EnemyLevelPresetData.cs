using UnityEngine;

namespace AP.EnemySystem
{
    [CreateAssetMenu(fileName = "Enemy Level Preset Data", menuName = "")]
    public class EnemyLevelPresetData : ScriptableObject
    {
        public float speed;
        public float scale = 1f;
        public Sprite mainSprite;
        public Sprite whiteSprite;
        public Vector3[] shadowCaster2DPath;
    }
}