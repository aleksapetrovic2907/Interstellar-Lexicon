namespace AP.ScoreSystem
{
    [System.Serializable]
    public class Score
    {
        public int Points { get; set; } = 0;
        public int WPM { get; set; } = 0;
        public float DifficultyMultiplier { get; set; } = 1f;

        public Score(int points, int wpm, float difficultyMultiplier)
        {
            Points = points;
            WPM = wpm;
            DifficultyMultiplier = difficultyMultiplier;
        }

        public Score() { }
    }
}