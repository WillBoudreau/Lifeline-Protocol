using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement References")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private InputActionAsset movementInputAction;
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 5f;

    void Update()
    {
        MovePlayer();
    }
    /// <summary>
    /// Moves the player based on the input from the movement input action.
    /// </summary>
    private void MovePlayer()
    {
        Vector2 movementInput = movementInputAction.FindAction("Move").ReadValue<Vector2>();
        playerRigidbody.linearVelocity = movementInput * movementSpeed;
    }
}
