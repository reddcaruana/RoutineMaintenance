using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class Inventory : IInventory
    {
        // Creates a list of items as soon as this
        // class starts to exist.
        private List<ItemType> items = new();

        public event Action<ItemType> Added;
        public event Action<ItemType> Removed;

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        public void Add(ItemType item)
        {
            items.Add(item);
            Added?.Invoke(item); // tell Added we added this item
        }

        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        public void Remove(ItemType item)
        {
            if (items.Remove(item))
                Removed?.Invoke(item);
        }

        /// <summary>
        /// Checks the inventory for an item.
        /// </summary>
        public bool Contains(ItemType item) => items.Contains(item);
    }

    public interface IInventory
    {
        // Action<T> -> T is a generic type that represents a type of variable
        event Action<ItemType> Added;
        event Action<ItemType> Removed;
        
        void Add(ItemType item);
        void Remove(ItemType item);
        bool Contains(ItemType item);
    }
}