using System;
using System.Collections.Generic;
using UnityEngine;

namespace AP
{
    public class TypingManager : GloballyAccessibleBase<TypingManager>
    {
        public string CurrentWord { get; private set; } = string.Empty;
        public float TimeSpentTyping { get; private set; } = 0f;

        public event Action<string> OnWordChanged;
        public event Action<string> OnWordSubmitted;

        private List<KeyCode> m_submitKeyCodes = new List<KeyCode>() { KeyCode.Return, KeyCode.KeypadEnter };
        private List<KeyCode> m_deleteKeyCodes = new List<KeyCode>() { KeyCode.Backspace, KeyCode.Delete };
        private List<KeyCode> m_alphabetKeyCodes = new List<KeyCode>();

        protected override void Awake()
        {
            base.Awake();
            InitializeAlphabetKeys();
        }

        private void Update()
        {
            // Submit word.
            if (m_submitKeyCodes.AnyKeyDown() && CurrentWord.Length > 0)
            {
                OnWordSubmitted?.Invoke(CurrentWord);
                CurrentWord = string.Empty;
                OnWordChanged?.Invoke(CurrentWord);
            }

            // Delete letter.
            if (m_deleteKeyCodes.AnyKeyDown() && CurrentWord.Length > 0)
            {
                CurrentWord = CurrentWord.Remove(CurrentWord.Length - 1, 1);
                OnWordChanged?.Invoke(CurrentWord);
            }

            // Add letter.
            if (CurrentWord.Length == WordsManager.LongestWord) return;

            foreach (KeyCode letter in m_alphabetKeyCodes)
            {
                if (Input.GetKeyDown(letter))
                {
                    CurrentWord += letter.ToString().ToLower();
                    OnWordChanged?.Invoke(CurrentWord);
                }
            }
        }

        private void LateUpdate()
        {
            if (CurrentWord.Length == 0) return;
            TimeSpentTyping += Time.unscaledDeltaTime;
        }

        private void InitializeAlphabetKeys()
        {
            for (char key = 'a'; key <= 'z'; key++)
                m_alphabetKeyCodes.Add((KeyCode)key);
        }
    }
}