using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Computer : MonoBehaviour, IInteractable, IBroken
    {
        [SerializeField] private Door door;
        [SerializeField] private bool isBroken = true;

        public event Action Broken;
        public event Action Repaired;

        /// <summary>
        /// Read by all classes, but only I can write
        /// </summary>
        public bool IsBroken { get; private set; }

        private void Start()
        {
            // Start by copying the design value
            IsBroken = isBroken;
            
            if (IsBroken)
                Broken?.Invoke(); // If Broken is not null, call the function
            else
                Repaired?.Invoke(); // If Repaired is not null, call the function
        }

        public void Interact(IInventory inventory)
        {
            if (IsBroken) // I don't work
            {
                // Broken and no fuse - doesn't work
                if (!inventory.Contains(ItemType.Fuse))
                    return;

                inventory.Remove(ItemType.Fuse);
                Fix();
                return;
            }

            door.Open();
        }

        public void Fix()
        {
            IsBroken = false; // I was fixed
            Repaired?.Invoke(); // If Repaired is not null, call the function
        }
    }
}