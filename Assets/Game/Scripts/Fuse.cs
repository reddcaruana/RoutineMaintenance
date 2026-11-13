using UnityEngine;

namespace Game.Scripts
{
    public class Fuse : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            GameManager.Instance.Inventory.TryAdd(ItemType.Fuse, 1);
            Destroy(gameObject);
        }
    }
}