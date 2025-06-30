using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    /// DA RICONTROLLARE DA REGISTRAZIONE COME HA CREATO QUESTO SCRIPT
    public void ChangeScene(string sceneName)
    {
        // Check if the scene name is not empty
        if (!string.IsNullOrEmpty(sceneName))
        {
            // Load the specified scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is empty. Cannot change scene.");
        }
    }
}
