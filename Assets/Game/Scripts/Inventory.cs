using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class Inventory : IInventory
    {
        public event Action Changed;

        private Dictionary<ItemType, int> items = new();

        public IReadOnlyDictionary<ItemType, int> Items => items;
        
        public bool TryAdd(ItemType item, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            
            // try to get the number of existing item
            items.TryGetValue(item, out var current); // Exports the quantity into current if the item exists
            items[item] = current + quantity;
            
            Changed?.Invoke();
            return true;
        }

        public bool TryRemove(ItemType item, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            if (!items.TryGetValue(item, out var current)) // item doesn't exist (and current == 0)
                return false;

            if (current < quantity)
                return false;

            var remaining = current - quantity;
            if (remaining <= 0)
                items.Remove(item);
            else
                items[item] = remaining;

            Changed?.Invoke();
            return true;
        }

        public bool TryRemove(ItemType item)
        {
            var success = items.Remove(item);
            
            if (success)
                Changed?.Invoke();
            
            return success;
        }

        public bool Contains(ItemType item, int quantity)
            => items.TryGetValue(item, out var current) && current >= quantity;
    }

    public interface IInventory
    {
        event Action Changed;
        
        IReadOnlyDictionary<ItemType, int> Items { get; }
        
        bool TryAdd(ItemType item, int quantity);
        bool TryRemove(ItemType item, int quantity);
        bool TryRemove(ItemType item);
        bool Contains(ItemType item, int quantity);
    }
}