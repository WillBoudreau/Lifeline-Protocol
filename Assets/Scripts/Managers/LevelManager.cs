using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// Loads the specified scene
    /// </summary>
    /// <param name="sceneName">The name of the scene to load</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
