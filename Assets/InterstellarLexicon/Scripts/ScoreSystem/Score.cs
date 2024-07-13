namespace AP.ScoreSystem
{
    [System.Serializable]
    public class Score
    {
        public int Points { get; private set; } = 0;
        public int WPM { get; private set; } = 0;
        public float DifficultyMultiplier { get; private set; } = 1f;

        public Score(int points, int wpm, float difficultyMultiplier)
        {
            Points = points;
            WPM = wpm;
            DifficultyMultiplier = difficultyMultiplier;
        }
    }
}