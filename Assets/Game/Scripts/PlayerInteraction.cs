using UnityEngine;

namespace Game.Scripts
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = Vector3.up;
    
        public void Interact(IInventory inventory)
        {
            var origin = transform.position + offset;
            if (!Physics.Raycast(origin, transform.forward, out var hitInfo, 2f))
                return;

            Debug.Log($"Object: {hitInfo.collider.name}");
        
            // Find and return a component if it exists
            if (hitInfo.collider.TryGetComponent(out Door door))
            {
                door.Open();
            }

            if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact(inventory);
            }
        }
    }
}
