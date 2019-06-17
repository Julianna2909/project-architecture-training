using Application;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
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
    }
}
