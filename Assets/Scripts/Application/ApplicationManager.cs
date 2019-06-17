using Game;
using MainMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Application
{
    public class ApplicationManager: MonoBehaviour
    {
        private static ApplicationManager instance;
        private static bool isInitializing;
        
        public static ApplicationManager Instance
        {
            get
            {
                if (instance == null && !isInitializing)
                {
                    isInitializing = true;
                    SceneManager.LoadScene(ApplicationScenes.Application.ToString());
                }
                return instance;
            }
            private set { instance = value; }
        }

        public MainMenuManager MainMenuManager { get; set; }
        public GameManager GameManager{ get; set; }
        public ApplicationScenes SelectedGameScene { get; set; }


        private void Awake()
        {
            DontDestroyOnLoad(this);
            isInitializing = false;
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
