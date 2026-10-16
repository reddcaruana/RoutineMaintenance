using UnityEngine;
using UnityEngine.InputSystem;

// Required by the script, and cannot be removed because they are essential
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // SerializeField exposes a variable in Unity
    [SerializeField] private float speed = 5f;
    // speed
    // gravity

    private CharacterController controller;
    
    private Vector2 direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(direction.x, 0, direction.y) * speed;
        
        // check if there is input
        if (direction.sqrMagnitude > 0.1f)
            transform.forward = movement.normalized;
        
        controller.Move(movement * Time.deltaTime);
    }

    public void Move(Vector2 input)
    {
        direction = input;
    }
}
