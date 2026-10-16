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
        // A reference to the components attached
        private PlayerMovement movement;
        private PlayerInteraction interaction;

        private void Awake()
        {
            movement = GetComponent<PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
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
            interaction.Interact();
        }
    }
}