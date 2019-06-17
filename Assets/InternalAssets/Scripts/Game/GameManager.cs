using System;
using InternalAssets.Scripts.Application;
using InternalAssets.Scripts.GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InternalAssets.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public event Action GameStop;
        
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private GameSceneManager gameSceneManager;
        [SerializeField] private Button backButton;
        [SerializeField] private Button replayButton;
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;
        public GameSceneManager GameSceneManager => gameSceneManager;

        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            backButton.onClick.AddListener(OnBackButtonClicked);
            replayButton.onClick.AddListener(OnReplayButtonClicked);
            replayButton.gameObject.SetActive(false);
            Debug.Log(ApplicationManager.Instance.SelectedGameScene.ToString());
            SceneManager.LoadScene(ApplicationManager.Instance.SelectedGameScene.ToString(), LoadSceneMode.Additive);
        }

        private void OnReplayButtonClicked()
        {
            SceneManager.UnloadScene(ApplicationManager.Instance.SelectedGameScene.ToString());
            SceneManager.LoadScene(ApplicationManager.Instance.SelectedGameScene.ToString(), LoadSceneMode.Additive);
        }

        public void RegisterGameSceneManager(GameSceneManager gameSceneManager)
        {
            this.gameSceneManager = gameSceneManager;
        }

        public void UNregisterGameSceneManager()
        {
            gameSceneManager = null;
        }

        public void AddScore()
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
        
        public void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(true); 
            GameStop?.Invoke();
        }
        
        private void OnBackButtonClicked() => SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());

        private void OnDestroy() => ApplicationManager.Instance.GameManager = null;
    }
}

