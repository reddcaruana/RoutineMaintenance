using Game.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Vector3 offset = Vector3.up;
    
    public void Interact()
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

        if (hitInfo.collider.TryGetComponent(out Computer computer))
        {
            computer.Use();
        }
    }
}
