using UnityEngine;
using TMPro;
using AP.ProjectileSystem;

namespace AP.UI
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counter;

        private void OnEnable()
        {
            ProjectilesManager.Instance.OnTargetShot += delegate { UpdateCounter(); };
        }

        private void OnDisable()
        {
            ProjectilesManager.Instance.OnTargetShot -= delegate { UpdateCounter(); };
        }

        private void UpdateCounter()
        {
            counter.text = string.Format("{0,7:D7}", GameManager.Instance.Points); 
        }
    }
}