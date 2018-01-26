using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void EnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void UnloadSceneAsync(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
}
