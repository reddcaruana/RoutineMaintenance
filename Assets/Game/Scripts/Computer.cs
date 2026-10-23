using UnityEngine;

namespace Game.Scripts
{
    public class Computer : MonoBehaviour, IInteractable
    {
        [SerializeField] private Door door;
        [SerializeField] private bool isBroken = true;
        
        public void Interact(Inventory inventory)
        {
            if (isBroken) // I don't work
            {
                Debug.Log("I am broken");
                // Broken and no fuse - doesn't work
                if (!inventory.Contains(ItemType.Fuse))
                {
                    Debug.Log("You don't have a fuse.");
                    return;
                }

                Debug.Log("I am fixed");
                inventory.Remove(ItemType.Fuse);
                isBroken = false; // I was fixed
                return;
            }

            Debug.Log("I feel used");
            door.Open();
        }
    }
}