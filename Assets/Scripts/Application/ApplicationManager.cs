using System;
using Game;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager : MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }
        
        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager { get; set; } 
        
        public ApplicationScenes SelectedGameScene { get; set; }
        

        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        private void Start()
        {
            SceneManager.LoadScene(ApplicationScenes.Menu.ToString());
        }
    }

    public enum ApplicationScenes
    {
        Application,
        Menu,
        Game
    }

    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] private ApplicationScenes scene;
        [SerializeField] private Wall wallPrefab;
        [SerializeField] private Player player;

        public Wall WallPrefab => wallPrefab;
        public Player Player => player;

        private void Awake()
        {
            ApplicationManager.Instance.GameManager.RegisterGameScene(this);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene.ToString()));

        }
    }
}
