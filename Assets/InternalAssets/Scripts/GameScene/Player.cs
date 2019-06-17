using InternalAssets.Scripts.Application;
using UnityEngine;

namespace InternalAssets.Scripts.GameScene
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float upForce;
        
        private bool isDead = false;

        private Rigidbody2D rigidbody;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (isDead) return;
            if (Input.GetMouseButtonDown(0)) 
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(new Vector2(0, upForce));
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            rigidbody.velocity = Vector2.zero;
            isDead = true;
            ApplicationManager.Instance.GameManager.GameOver();
        }
    }
}