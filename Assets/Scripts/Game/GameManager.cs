using System;
using Application;
using GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public event Action StopScrolling;
        
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private GameSceneManager gameSceneManager;
        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int score = 0;

        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            backButton.onClick.AddListener(OnBackButtonClicked);
            Debug.Log(ApplicationManager.Instance.SelectedGameScene.ToString());
            SceneManager.LoadScene(ApplicationManager.Instance.SelectedGameScene.ToString(), LoadSceneMode.Additive);
        }

        public void RegisterGameSceneManager(GameSceneManager gameSceneManager)
        {
            this.gameSceneManager = gameSceneManager;
            //StartGame();
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
            StopScrolling?.Invoke();
        }

        private void OnBackButtonClicked() => SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());

        private void OnDestroy() => ApplicationManager.Instance.GameManager = null;
    }
}

