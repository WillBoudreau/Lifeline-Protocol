using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private CharacterTraits characterTraits;

    void Awake()
    {
        Debug.Log("Character Manager Awake");
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
        characterStats.SetStats();
        characterTraits.SetTraits(characterTraits.currentTraits, characterTraits.currentSkills);
    }
    void Update()
    {
        playerMovement.MovePlayer(characterStats.currentSpeed);
    }

}
