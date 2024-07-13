using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace AP.ScoreSystem
{
    public class ScoresManager : MonoBehaviour
    {
        public static IReadOnlyList<Score> Scores = s_scores.AsReadOnly();

        private static List<Score> s_scores = new();

        private const string FILE_NAME = "/scores.xml";

        private void Awake() => LoadScores();

        public void AddScore(Score score)
        {
            int index = s_scores.FindIndex(entry => score.Points > entry.Points);

            // Add to list while leaving it descending by points.
            if (index >= 0)
                s_scores.Insert(index, score);
            else
                s_scores.Add(score);
        }

        private void OnApplicationQuit() => SaveScores();

        #region SAVE_SYSTEM
        private void SaveScores()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoresListEntry));
            FileStream fileStream = File.Create(Path.Combine(Application.persistentDataPath, FILE_NAME));
            ScoresListEntry scoresListEntry = new(s_scores);
            xmlSerializer.Serialize(fileStream, scoresListEntry);
            fileStream.Close();
        }

        private void LoadScores()
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath, FILE_NAME)))
            {
                return;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoresListEntry));
            FileStream fileStream = File.Open(Path.Combine(Application.persistentDataPath, FILE_NAME), FileMode.Open);
            s_scores = new((xmlSerializer.Deserialize(fileStream) as ScoresListEntry).scores);
            fileStream.Close();
        }
        #endregion
    }
}