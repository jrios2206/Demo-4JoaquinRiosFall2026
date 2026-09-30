using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction playerMove;
    private InputAction playerLook;
    private CharacterController controller;
    public float mouseSensitivity = 0.1f;
    public float playerMoveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerMove = InputSystem.actions.FindAction("Move");
        playerLook = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = playerMove.ReadValue<Vector2>(); //x and y wsad, getting values..
        Vector2 lookValue = playerLook.ReadValue<Vector2>(); // x and y  mouse, getting values..
        Vector3 movement = transform.forward * moveValue.y + transform.right * moveValue.x;
        controller.Move(movement * (playerMoveSpeed * Time.deltaTime));
        transform.Rotate(0,lookValue.x * mouseSensitivity,0);
    }
}
