using System;
using System.Collections;
using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public event Action ColorChange;
        
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private Button backButton;
        [SerializeField] private Button changeButton;
        [SerializeField] private Image image;

        private void Awake()
        {
            ApplicationManager.Instance.GameManager = this;
            SceneManager.LoadScene(ApplicationManager.Instance.SelectedGameScene.ToString(), LoadSceneMode.Additive);
            backButton.onClick.AddListener(OnBackButtonClicked);
            changeButton.onClick.AddListener(OnChange);
            ColorChange += OnColorChange;
        }

        private void StartGame()
        {
            StartSpawningWalls(currentGameScene);
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            var timeElapsed = 0f;
            while (true)
            {
                if (timeElapsed > spawnRate)
                {
                    timeElapsed = 0f;
                    var newWall = Instantiate(wallPrefab);
                    newWall.Init();
                    newWall.WallPassed += OnWallPassed;
                }

                timeElapsed += Time.deltaTime;
                
                yield return null;
            }
        }

        private void OnWallPassed(Wall thisWall)
        {
            thisWall.WallPassed -= OnWallPassed;
            
        }

        private void OnChange() => ColorChange?.Invoke();

        private void OnColorChange() => image.color = GetRandomColor();

        public Color GetRandomColor()
        {
            int maxIndex = gameConfig.Colors.Count;
            int randomIndex = Random.Range(0, maxIndex);
            return gameConfig.Colors[randomIndex];
        }

        private void OnBackButtonClicked() => SceneManager.LoadScene("Menu");

        private void OnDestroy()
        {
            ColorChange -= OnColorChange;
            ApplicationManager.Instance.GameManager = null;
        }
    }
}

