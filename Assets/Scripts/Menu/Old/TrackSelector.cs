using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(SceneLoader))]
public class TrackSelector : MonoBehaviour
{
    private Text text;
    private Button button;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        button.interactable = true;
    }

    public void SelectTrack(Text text)
    {
        button.interactable = false;
        SceneLoader.instance.PreloadScene(text.text, true);
    }

    private void Update()
    {
        if(button.interactable == false)
        {
            text.text = SceneLoader.instance.Progress.ToString() + "%";
        }
    }
}
