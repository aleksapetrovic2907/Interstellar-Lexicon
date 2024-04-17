using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace AP
{
    public static class WordsManager
    {
        public static int LongestWord { get; private set; } = 0;

        static readonly TextAsset wordsTextFile;
        static readonly List<string> words;

        static WordsManager()
        {
            wordsTextFile = Resources.Load<TextAsset>("words_eng");
            words = wordsTextFile.text.Split('\n').Select(p => p.Trim().ToLower()).ToList();

            for (int i = 0; i < words.Count; i++)
                if (words[i].Length > LongestWord) LongestWord = words[i].Length;
        }

        public static string GetRandomWord()
        {
            return words.GetRandomElement();
        }
    }
}