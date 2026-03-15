using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics.Contracts;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject characterStatsUI;
    public GameObject loadingScreen;

    [Header("Loading Screen Settings")]
    [SerializeField] private float loadingScreenFadeDuration = 1f;
    public CanvasGroup loadingScreenCanvasGroup;
    public Image loadingBar;
    public float loadSpeed = 2f;

    private void Start()
    {
        DisableAllUI();
        mainMenu.SetActive(true);
    }

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
        loadingScreen.SetActive(false);
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
            case "LoadingScreen":
                loadingScreen.SetActive(true);
                break;
            default:
                Debug.LogWarning("UIManager: Unknown UI name: " + uiName);
                break;
        }
    }

    /// <summary>
    /// Starts the loading screen process
    /// </summary>
    public void UILoadingScreen(GameObject targetUI)
    {
        StartCoroutine(LoadingScreenFadeIn());
        StartCoroutine(WaitForLoadingScreen(loadingScreenFadeDuration, targetUI));
    }
    /// <summary>
    /// Handles the loading screen fade in
    /// </summary>
    private IEnumerator LoadingScreenFadeIn()
    {
        DisableAllUI();
        float timer = 0f;

        loadingScreen.SetActive(true);
        while (timer < loadingScreenFadeDuration)
        {
            timer += Time.deltaTime;
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / loadingScreenFadeDuration);
            yield return null;
        }
        StartCoroutine(FillLoadingBar());
    }
    /// <summary>
    /// Handles the loading screen fade out
    /// </summary>
    private IEnumerator LoadingScreenFadeOut()
    {
        float timer = 0f;

        while (timer < loadingScreenFadeDuration)
        {
            timer += Time.deltaTime;
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / loadingScreenFadeDuration);
            yield return null;
        }
        loadingScreenCanvasGroup.alpha = 0f;
        loadingScreen.SetActive(false);
        loadingBar.fillAmount = 0f;
    }
    /// <summary>
    /// Waits for the loading screen to finish fading in before enabling the target UI
    /// <param name="waitTime">The time to wait before enabling the target UI</param>
    /// <param name="targetUI">The UI to enable after the loading screen</param>
    /// </summary>
    private IEnumerator WaitForLoadingScreen(float waitTime, GameObject targetUI)
    {
        yield return new WaitForSeconds(waitTime);
        DisableAllUI();
        targetUI.SetActive(true);
    }
    ///<summary>
    /// Updates the loading bar fill amount
    /// </summary>
    public IEnumerator FillLoadingBar()
    {
        float timer = 0f;
        loadingBar.fillAmount = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime/2;
            loadingBar.fillAmount += Time.deltaTime/2;
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(LoadingScreenFadeOut());
    }
}
