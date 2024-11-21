using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MWA_SceneLoaderScript : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        else
        {
            Debug.LogWarning("Scene name is empty.");
        }
    }
    public void UnloadGame(string sceneName) // call this method on gameover, apply on buttons like 'back to menu'
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogWarning($"Scene '{sceneName}' is not loaded.");
        }
    }
}
