using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button gameScene1;
        [SerializeField] private Button gameScene2;
        [SerializeField] private Button gameScene3;
        
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            gameScene1.onClick.AddListener(OnGameScene1Clicked);
            gameScene2.onClick.AddListener(OnGameScene2Clicked);
            gameScene3.onClick.AddListener(OnGameScene3Clicked);
        }

        private void OnGameScene1Clicked()
        {
            SelectGameScene(ApplicationScenes.GameScene1);
        }

        private void OnGameScene2Clicked()
        {
            SelectGameScene(ApplicationScenes.GameScene2);
        }

        private void OnGameScene3Clicked()
        {
            SelectGameScene(ApplicationScenes.GameScene3);
        }

        private void SelectGameScene(ApplicationScenes scene)
        {
            ApplicationManager.Instance.SelectedGameScene = scene;
            SceneManager.LoadScene(ApplicationScenes.Game.ToString());
        }

        private void OnDestroy() => ApplicationManager.Instance.MainMenuManager = null;
    }
}

