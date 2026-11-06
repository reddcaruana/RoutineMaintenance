using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerInteraction))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private InventoryUI inventoryUI;
        
        // A reference to the components attached
        private PlayerMovement movement;
        private PlayerInteraction interaction;

        // Create an inventory for this player
        private IInventory inventory = new Inventory();

        private void Awake()
        {
            movement = GetComponent<PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
        }

        private void Start()
        {
            inventoryUI.SetInventory(inventory);
        }

        // Take input from Player Input and pass it on to the other scripts

        // Received by the PlayerInput component
        // when WASD is pressed
        private void OnMove(InputValue value)
        {
            var input = value.Get<Vector2>();
            movement.Move(input);
        }

        private void OnInteract(InputValue value)
        {
            interaction.Interact(inventory);
        }
    }
}