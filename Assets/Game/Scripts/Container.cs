using UnityEngine;

namespace Game.Scripts
{
    // Through IInteractable, the default interaction
    // works automatically
    public class Container : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemType item;
        [SerializeField] private int quantity = 1;
        
        public void Interact()
        {
            GameManager.Instance.Inventory.TryAdd(item, quantity);
        }
    }
}