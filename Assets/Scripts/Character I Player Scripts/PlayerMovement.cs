using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement References")]
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private InputActionAsset movementInputAction;

    /// <summary>
    /// Moves the player based on the input from the movement input action.
    /// </summary>
    public void MovePlayer(float movementSpeed)
    {
        Vector2 movementInput = movementInputAction.FindAction("Move").ReadValue<Vector2>();
        playerRigidbody.linearVelocity = movementInput * movementSpeed;
        Debug.Log($"Player Movement Input: {movementInput}, Speed: {movementSpeed}");
    }
}
