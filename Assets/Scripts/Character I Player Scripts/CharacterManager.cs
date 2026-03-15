using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private CharacterTraits characterTraits;
    [SerializeField] private PlayerInteractions playerInteractions;

    void Awake()
    {
        if (playerMovement == null)
        {
            playerMovement = GetComponent<PlayerMovement>();
        }
        if (characterStats == null)
        {
            characterStats = GetComponent<CharacterStats>();
        }
        if (characterTraits == null)
        {
            characterTraits = GetComponent<CharacterTraits>();
        }
        if (playerInteractions == null)
        {
            playerInteractions = GetComponent<PlayerInteractions>();
        }
        characterStats.SetStats();
        characterTraits.SetTraits(characterTraits.currentTraits, characterTraits.currentSkills);
    }
    void Update()
    {
        playerMovement.MovePlayer(characterStats.currentSpeed);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            playerInteractions.currentObstacle = other.gameObject;
            playerInteractions.isInteracting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            playerInteractions.currentObstacle = null;
            playerInteractions.isInteracting = false;
            other.GetComponent<ObstacleBehaviour>().ResetObstacle();
        }
    }

}
