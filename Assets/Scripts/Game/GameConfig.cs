using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private List<Color> colors;
        
        public List<Color> Colors => colors;
    }
}
