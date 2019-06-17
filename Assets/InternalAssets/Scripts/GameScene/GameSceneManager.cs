using InternalAssets.Scripts.Application;
using InternalAssets.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InternalAssets.Scripts.GameScene
{
    public class GameSceneManager : MonoBehaviour
    {
        [SerializeField] private Wall wallPrefab;
        [SerializeField] private Player player;

        public Wall WallPrefab => wallPrefab;
        public Player Player => player;
        
        private void Start()
        {
            ApplicationManager.Instance.GameManager.RegisterGameSceneManager(this);
            
            SceneManager.SetActiveScene(gameObject.scene);
            Debug.Log(SceneManager.GetActiveScene().name);
        }

 //       private void OnDestroy()
 //       {
 //           ApplicationManager.Instance.GameManager.UNregisterGameSceneManager();
 //       }
  }
}
