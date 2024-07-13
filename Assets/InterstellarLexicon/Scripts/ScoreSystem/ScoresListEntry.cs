using System.Collections.Generic;

namespace AP.ScoreSystem
{
    [System.Serializable]
    public class ScoresListEntry
    {
        public List<Score> scores;
        public ScoresListEntry(List<Score> scores) => this.scores = new List<Score>(scores);
    }
}