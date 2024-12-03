using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MWA_SceneLoaderScript : MonoBehaviour
{
    public void LoadGame(string sceneName)
    {
        // Check if the level has been played already
        if (GameManager.Instance.GetLevelStatus(sceneName) == "not played")
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                // Load the scene
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
