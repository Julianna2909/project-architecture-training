using UnityEngine;

namespace Game
{
    public class RepeatingGround : MonoBehaviour
    {
        private BoxCollider2D groundCollider;
        private float groundHorizontalLength;

        private void Awake ()
        {
            groundCollider = GetComponent<BoxCollider2D>();
            groundHorizontalLength = groundCollider.size.x;
        }

        private void Update()
        {
            if (transform.position.x < -groundHorizontalLength) RepositionCollider();
        }

        private void RepositionCollider()
        {
            Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
            transform.position = (Vector2) transform.position + groundOffSet;
        }
    }
}
