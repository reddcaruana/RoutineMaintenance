using System;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    public class InventoryUI : MonoBehaviour
    {
        // I need to know what I'm linked with
        private IInventory inventory;

        // Set and subscribe
        public void SetInventory(IInventory newInventory)
        {
            inventory = newInventory;
            inventory.Added += OnItemAdded;
        }

        // Unsubscribe to clean up
        private void OnDisable()
        {
            // Player might not have set this at all; avoid errors
            if (inventory != null)
            {
                inventory.Added -= OnItemAdded;
            }
        }

        private void OnItemAdded(ItemType item)
        {
            Debug.Log($"Added a(n) {item}");
        }
    }
}