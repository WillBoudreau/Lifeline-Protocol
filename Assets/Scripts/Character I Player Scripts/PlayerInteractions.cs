using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private InputActionAsset interactionInputAction;
    public GameObject currentObstacle;

    /// <summary>
    /// Interacts with the obstalce when the player presses the interact button
    /// </summary>
    public void Interact(GameObject currentObstacle)
    {
        if (interactionInputAction.FindAction("Interact").triggered)
        {
            Debug.Log("Interacting with obstacle: " + currentObstacle.name);
        }
    }
    void Update()
    {
        if (interactionInputAction.FindAction("Interact").triggered && currentObstacle != null)
        {
            Interact(currentObstacle);
        }
    }
}
