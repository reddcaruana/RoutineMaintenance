using UnityEngine;

namespace Game.Scripts
{
    public class Fuse : MonoBehaviour, IInteractable
    {
        public void Interact(IInventory inventory)
        {
            inventory.Add(ItemType.Fuse);
            Destroy(gameObject);
        }
    }
}