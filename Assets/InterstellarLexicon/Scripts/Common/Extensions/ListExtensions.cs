using System.Collections.Generic;
using UnityEngine;

namespace AP
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this List<T> list)
        {
            var randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }
    }
}