using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePreparer : Singleton<ScenePreparer>
{
    public static string ShipName;

    private AsyncOperation async;

    private void Start()
    {
        async = SceneManager.LoadSceneAsync("TrackSelector");
        async.allowSceneActivation = false;
    }

    public void SelectShip(Text Text)
    {
        SelectShip(Text.text);
    }
    public void SelectShip(string name)
    {
        ShipName = name;
        async.allowSceneActivation = true;

    }
    public void SelectTrack(string name)
    {
        SceneManager.LoadScene(name);
    }
}
