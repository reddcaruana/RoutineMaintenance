using UnityEngine;

namespace Game.Scripts
{
    // Exposes the contents in the inspector :)))
    [System.Serializable]
    public struct GameContext
    {
        public TitleUI TitleScreen;
        
        public GameObject Player;
    }
}