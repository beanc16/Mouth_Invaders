using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        // Scene CAN be loaded
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }

        // Scene CAN NOT be loaded
        else
        {
            Debug.LogError(sceneName + " could not be loaded as a " + 
                           "scene. Please check your build settings " +
                           "and scene name.");
        }
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
