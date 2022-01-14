using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Ship))]
public class Player : MonoBehaviour {
    private Ship ship;
    private PlayerInput playerInput;
    private InputAction moveAction;

    private Vector2 desiredVelocity;

    private void Awake() {
        ship = GetComponent<Ship>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    // Called on each frame. While this is unsuitable for physics, it is ideal
    // for polling inputs.
    private void Update() {
        var inputDir = moveAction.ReadValue<Vector2>();
        ship.ApplyInput(inputDir.y, inputDir.x);
    }
}
