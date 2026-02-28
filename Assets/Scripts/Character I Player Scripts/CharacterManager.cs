using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Character References")]
    public PlayerMovement playerMovement;
    public CharacterStats characterStats;

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
        characterStats.SetStats();
    }
    void Update()
    {
        playerMovement.MovePlayer(characterStats.currentSpeed);
    }

}
