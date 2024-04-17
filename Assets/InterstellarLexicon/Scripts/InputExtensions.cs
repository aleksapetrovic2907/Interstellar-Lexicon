using System.Collections.Generic;
using UnityEngine;

namespace AP
{
    public static class InputExtensions
    {
        public static bool AnyKeyDown(this List<KeyCode> keys)
        {
            bool anyKeyPressed = false;

            foreach (KeyCode keyCode in keys)
            {
                if (!Input.GetKeyDown(keyCode)) continue;
                anyKeyPressed = true;
                break;
            }

            return anyKeyPressed;
        }
    }
}