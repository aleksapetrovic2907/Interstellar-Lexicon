using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP.EnemySystem
{
    // Sorting of all enemy level presets based on word length.
    public class EnemyPresetsManager : GloballyAccessibleBase<EnemyPresetsManager>
    {
        [SerializeField] private List<PresetsByWordLength> presetsByWordLength;

        public EnemyLevelPresetData GetPresetDataBasedOnWord(string word)
        {
            var length = word.Length;
            var level = 0;

            for (int i = 0; i < presetsByWordLength.Count; i++)
            {
                if (length >= presetsByWordLength[i].range.x && length < presetsByWordLength[i].range.y)
                {
                    level = i;
                    break;
                }
            }

            return presetsByWordLength[level].enemyLevelPresetData;
        }
    }

    [Serializable]
    public class PresetsByWordLength
    {
        [Tooltip("Min inclusive. Max exclusive.")] public Vector2Int range;
        public EnemyLevelPresetData enemyLevelPresetData;
    }
}