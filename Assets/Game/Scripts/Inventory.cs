using System.Collections.Generic;

public class Inventory
{
    // Creates a list of items as soon as this
    // class starts to exist.
    private List<ItemType> items = new();

    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    public void Add(ItemType item) => items.Add(item);

    /// <summary>
    /// Removes an item from the inventory.
    /// </summary>
    public void Remove(ItemType item) => items.Remove(item);

    /// <summary>
    /// Checks the inventory for an item.
    /// </summary>
    public bool Contains(ItemType item) => items.Contains(item);
}