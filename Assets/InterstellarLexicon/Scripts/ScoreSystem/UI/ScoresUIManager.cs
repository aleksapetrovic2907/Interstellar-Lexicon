using UnityEngine;

namespace AP.ScoreSystem.UI
{
    public class ScoresUIManager : MonoBehaviour
    {
        [SerializeField] private ScoreUI scoreUIPrefab;
        [SerializeField] private RectTransform scoresParent;
        [SerializeField] private int scoresToDisplayCount;

        private void Awake() => GenerateScoresList();

        private void GenerateScoresList()
        {
            for (int i = 0; i < scoresToDisplayCount; i++)
            {
                ScoreUI scoreUI = Instantiate(scoreUIPrefab, scoresParent);

                if (i >= ScoresManager.Scores.Count)
                {
                    scoreUI.Initialize(new Score(0, 0, 0f));
                }
                else
                {
                    scoreUI.Initialize(ScoresManager.Scores[i]);
                }
            }
        }
    }
}