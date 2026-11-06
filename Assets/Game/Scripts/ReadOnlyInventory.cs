using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class ReadOnlyInventory : IInventory
    {
        // These are the items the player will start with
        private List<ItemType> items = new() { ItemType.Fuse };

        public event Action<ItemType> Added;
        public event Action<ItemType> Removed;
        public void Add(ItemType item) => Debug.Log("The Inventory is Read Only!!");

        public void Remove(ItemType item)
        {
            if (items.Remove(item))
                Removed?.Invoke(item);
        }

        public bool Contains(ItemType item) => items.Contains(item);
    }
}