using Application;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        
        private void Awake()
        {
            ApplicationManager.Instance.MainMenuManager = this;
            playButton.onClick.AddListener(OnPlay);
        }

        private void OnPlay() => SceneManager.LoadScene("Game");


        private void OnDestroy() => ApplicationManager.Instance.MainMenuManager = null;
    }
}
