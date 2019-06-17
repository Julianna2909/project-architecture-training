using InternalAssets.Scripts.Application;
using UnityEngine;

namespace InternalAssets.Scripts.GameScene
{
    public class Wall : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag.Equals("Player")) ApplicationManager.Instance.GameManager.AddScore();
        }
    }
}