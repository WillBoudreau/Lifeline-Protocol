using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private InputActionAsset interactionInputAction;
    public bool isInteracting;
    public GameObject currentObstacle;

    /// <summary>
    /// Interacts with the obstalce when the player presses the interact button
    /// </summary>
    public void Interact(GameObject currentObstacle)
    {
        if (interactionInputAction.FindAction("Interact").triggered && isInteracting == true)
        {
            StartCoroutine(currentObstacle.GetComponent<ObstacleBehaviour>().FixObstacle());
        }
    }
    void Update()
    {
        if(currentObstacle != null)
        {
            if (interactionInputAction.FindAction("Interact").triggered && isInteracting == true)
            {
                Interact(currentObstacle);
            }
        }
    }
}
