using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePreparer : Singleton<ScenePreparer> {

    public static string ShipName;

    public void SelectShip(Text Text)
    {
        SelectShip(Text.text);
    }
    public void SelectShip(string name)
    {
        ShipName = name;
        SceneManager.LoadScene("TrackSelector");
    }
    public void SelectTrack(string name)
    {
        SceneManager.LoadScene(name);
    }
}
