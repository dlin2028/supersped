using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TrackSelector : MonoBehaviour {

	public void Select(Text Text)
    {
        Select(Text.text);
    }
    public void Select(string name)
    {
        SceneManager.LoadScene(name);
    }
}
