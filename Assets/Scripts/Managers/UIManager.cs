using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject characterStatsUI;
  
    /// <summary>
    /// Sets all the UIs to false
    /// </summary>
    public void DisableAllUI()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        inventoryUI.SetActive(false);
        characterStatsUI.SetActive(false);
        gameplayUI.SetActive(false);
    }
    /// <summary>
    /// Sets the specified UI to true
    /// </summary>
    /// <param name="ui">The UI to enable</param>
    public void EnableUI(string uiName)
    {
        DisableAllUI();
        switch (uiName)
        {
            case "MainMenu":
                mainMenu.SetActive(true);
                break;
            case "PauseMenu":
                pauseMenu.SetActive(true);
                break;
            case "GameOverMenu":
                gameOverMenu.SetActive(true);
                break;
            case "InventoryUI":
                inventoryUI.SetActive(true);
                break;
            case "CharacterStatsUI":
                characterStatsUI.SetActive(true);
                break;
            case "GameplayUI":
                gameplayUI.SetActive(true);
                break;
            default:
                Debug.LogWarning("UIManager: Unknown UI name: " + uiName);
                break;
        }
    }
}
