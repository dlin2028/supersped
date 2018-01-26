using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(SceneLoader))]
public class ScenePreparer : Singleton<ScenePreparer>
{
    public static string ShipName;

    public void SelectShip(Text Text)
    {
        SelectShip(Text.text);
    }
    public void SelectShip(string name)
    {
        ShipName = name;

        //GetComponent<SceneLoader>().LoadScene();
    }
}
