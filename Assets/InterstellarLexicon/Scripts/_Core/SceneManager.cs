using UnityEngine;

namespace AP
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }

        private const int MENU_SCENE_INDEX = 1;
        private const int GAME_SCENE_INDEX = 2;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadMenuScene();
        }

        public void LoadMenuScene() => UnityEngine.SceneManagement.SceneManager.LoadScene(MENU_SCENE_INDEX);
        public void LoadGameScene() => UnityEngine.SceneManagement.SceneManager.LoadScene(GAME_SCENE_INDEX);
    }
}
