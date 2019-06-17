using InternalAssets.Scripts.Application;
using UnityEngine;

namespace InternalAssets.Scripts.Game
{
    public class ScrollingObject : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        public float scrollSpeed = -1.5f;

        void Start () 
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2 (scrollSpeed, 0);

            ApplicationManager.Instance.GameManager.GameStop += OnGameStopScrolling;
        }

        private void OnGameStopScrolling()
        {
            ApplicationManager.Instance.GameManager.GameStop -= OnGameStopScrolling;
            rigidbody.velocity = Vector2.zero;
            
        }
    }
}

