using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePreparer : Singleton<ScenePreparer>
{
    public static string ShipName;

    public bool Preload = false;

    private AsyncOperation async;

    private void Start()
    {
        if(Preload)
        {
            async = SceneManager.LoadSceneAsync("TrackSelector");
            async.allowSceneActivation = false;
        }
    }

    public void SelectShip(Text Text)
    {
        SelectShip(Text.text);
    }
    public void SelectShip(string name)
    {
        ShipName = name;
        if(Preload)
        {
            async.allowSceneActivation = true;
        }
        else
        {
            SceneManager.LoadScene("TrackSelector");
        }

    }
    public void SelectTrack(string name)
    {
        SceneManager.LoadScene(name);
    }
}
