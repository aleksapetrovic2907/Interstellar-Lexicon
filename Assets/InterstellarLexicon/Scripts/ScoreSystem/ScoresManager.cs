using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace AP.ScoreSystem
{
    public class ScoresManager : MonoBehaviour
    {
        public static ScoresManager Instance { get; private set; }
        public static List<Score> Scores = new();

        private const string FILE_NAME = "scores.xml";

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadScores();
        }

        public void AddScore(Score score)
        {
            int index = Scores.FindIndex(entry => score.Points > entry.Points);

            // Add to list while leaving it descending by points.
            if (index >= 0)
                Scores.Insert(index, score);
            else
                Scores.Add(score);
        }

        private void OnApplicationQuit() => SaveScores();

        #region SAVE_SYSTEM
        private void SaveScores()
        {
            XmlSerializer xmlSerializer = new(typeof(ScoresListEntry));
            FileStream fileStream = File.Create(Path.Combine(Application.persistentDataPath, FILE_NAME));
            ScoresListEntry scoresListEntry = new(Scores);
            xmlSerializer.Serialize(fileStream, scoresListEntry);
            fileStream.Close();
        }

        private void LoadScores()
        {
            Scores = new List<Score>();

            if (!File.Exists(Path.Combine(Application.persistentDataPath, FILE_NAME)))
            {
                return;
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ScoresListEntry));
            FileStream fileStream = File.Open(Path.Combine(Application.persistentDataPath, FILE_NAME), FileMode.Open);
            Scores = new((xmlSerializer.Deserialize(fileStream) as ScoresListEntry).scores);
            fileStream.Close();
        }
        #endregion
    }
}