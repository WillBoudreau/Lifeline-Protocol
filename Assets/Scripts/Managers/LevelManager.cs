using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private float levelLoadDelay = 2f;
    [SerializeField] private string nextLevelName;
    public List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public int activeLevelNumber;
    public string sceneName;
    [Header("Level References")]
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
    }

    /// <summary>
    /// Loads the level based on the sceneName variable
    /// </summary>
    public void LoadLevel(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        uiManager.UILoadingScreen(uiManager.loadingScreen);
        StartCoroutine(WaitForScreenLoad(sceneName));
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneName)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    /// <summary>
    /// Waits for the screen to load before starting the laoding process
    /// </summary>
    private IEnumerator WaitForScreenLoad(string sceneName)
    {
        
        yield return new WaitForSeconds(uiManager.loadSpeed);

        yield return new WaitForSeconds(levelLoadDelay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncLoad.completed += OperationCompleted;
        scenesToLoad.Add(asyncLoad);
    }
    /// <summary>
    /// Called when the scene has finished loading
    /// </summary>
    private void OperationCompleted(AsyncOperation obj)
    {
        scenesToLoad.Remove(obj);
        Debug.Log("Scene Loaded");
    }
}
