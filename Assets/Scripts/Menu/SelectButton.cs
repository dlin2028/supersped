using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectButton : MonoBehaviour {

    private Text text;
    private bool updateText;

    private void Start()
    {
        SceneLoader.instance.PreloadScene("TrackSelector");
        text = GetComponentInChildren<Text>();
        GetComponent<Button>().interactable = false;
        updateText = true;
    }

    private void Update()
    {
        if(SceneLoader.instance.Progress < 0.9f)
        {
            text.text = SceneLoader.instance.Progress.ToString() + "%";
        }
        else if(updateText == true)
        {
            GetComponent<Button>().interactable = true;
            text.text = "SELECT";
            updateText = false;
        }
    }

    public void SelectShip(Text text)
    {
        GlobalVars.ShipName = text.text;
        SceneLoader.instance.AllowActivation();
    }
}
