using Game.Scripts;
using UnityEngine;

public class Fuse : MonoBehaviour, IInteractable
{
    public void Interact(Inventory inventory)
    {
        inventory.Add(ItemType.Fuse);
        Destroy(gameObject);
    }
}