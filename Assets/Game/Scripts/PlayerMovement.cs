using UnityEngine;
using UnityEngine.InputSystem;

// Required by the script, and cannot be removed because they are essential
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    // SerializeField exposes a variable in Unity
    [SerializeField] private float speed = 5f;
    // speed
    // gravity

    private CharacterController controller;
    
    private Vector2 input;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = new Vector3(input.x, 0, input.y);
        controller.Move(movement * Time.deltaTime);
    }

    // Received by the PlayerInput component
    // when WASD is pressed
    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>() *  speed;
    }
}
