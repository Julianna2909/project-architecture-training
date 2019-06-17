using InternalAssets.Scripts.Game;
using InternalAssets.Scripts.MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InternalAssets.Scripts.Application
{
    public class ApplicationManager: MonoBehaviour
    {
        public static ApplicationManager Instance { get; private set; }
        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager{ get; set; } 
        public ApplicationScenes SelectedGameScene { get; set; }


        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        private void Start()
        {
            SceneManager.LoadScene(ApplicationScenes.MainMenu.ToString());
        }
    }
    
    public enum ApplicationScenes
    {
        Application,
        MainMenu,
        Game,
        GameScene1,
        GameScene2,
        GameScene3
    }
}
