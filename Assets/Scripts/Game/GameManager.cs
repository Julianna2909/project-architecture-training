using System;
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
            backButton.onClick.AddListener(OnBack);
            changeButton.onClick.AddListener(OnChange);
            ColorChange += OnColorChange;
        }

        private void OnChange() => ColorChange?.Invoke();

        private void OnColorChange() => image.color = GetRandomColor();

        public Color GetRandomColor()
        {
            int maxIndex = gameConfig.Colors.Count;
            int randomIndex = Random.Range(0, maxIndex);
            return gameConfig.Colors[randomIndex];
        }

        private void OnBack() => SceneManager.LoadScene("Menu");

        private void OnDestroy()
        {
            ColorChange -= OnColorChange;
            ApplicationManager.Instance.GameManager = null;
        }
    }
}

