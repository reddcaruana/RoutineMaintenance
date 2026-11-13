using System;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

namespace Game.Scripts
{
    // Singleton Pattern - one global instance available to the game
    public partial class GameManager : MonoBehaviour
    {
        // One for the class (doesn't exist in the instance)
        [AutoStaticsCleanup]
        private static GameManager instance;

        public static GameManager Instance => instance;

        // Read-Only variable for Inventory
        public IInventory Inventory { get; } = new Inventory();

        // Enforce that there is only ever one GameManager in the game
        private void Awake()
        {
            if (instance) // Object exists - DELETE
            {
                DestroyImmediate(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            // If the scene changes, this object stays
        }

        private void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }
    }
}