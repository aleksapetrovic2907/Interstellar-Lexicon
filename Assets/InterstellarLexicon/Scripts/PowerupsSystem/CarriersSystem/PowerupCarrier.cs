using UnityEngine;
using AP.UI;

namespace AP.PowerupsSystem.CarriersSystem
{
    public class PowerupCarrier : MonoBehaviour
    {
        public PowerupType powerupType;
        public string word;

        [SerializeField] private GameObject wordTitlePrefab;
        [SerializeField] private Transform titleLocation;

        private WordUI m_title;

        private void Start()
        {
            m_title = Instantiate(wordTitlePrefab, WordTitlesCanvas.Instance.transform).GetComponent<WordUI>();
            m_title.SetData(titleLocation, word);
        }

        private void OnDestroy()
        {
            if (m_title != null) Destroy(m_title.gameObject);
        }
    }
}