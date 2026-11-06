using UnityEngine;

namespace Game.Scripts
{
    // Through IInteractable, the default interaction
    // works automatically
    public class Container : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemType item;
        
        public void Interact(IInventory inventory)
        {
            inventory.Add(item);
        }
    }
}