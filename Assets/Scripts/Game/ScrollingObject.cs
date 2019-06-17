using Application;
using UnityEngine;

namespace Game
{
    public class ScrollingObject : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        public float scrollSpeed = -1.5f;

        void Start () 
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = new Vector2 (scrollSpeed, 0);

            ApplicationManager.Instance.GameManager.StopScrolling += OnStopScrolling;
        }

        private void OnStopScrolling()
        {
            ApplicationManager.Instance.GameManager.StopScrolling -= OnStopScrolling;
            rigidbody.velocity = Vector2.zero;
        }

    }
}

