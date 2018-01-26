using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public string PreloadName;

    [HideInInspector]
    public float Progress
    {
        get
        {
            return async.progress * 100;
        }
    }

    private AsyncOperation async;

    protected SceneLoader() { } //make sure no other instances are made

    private void Start()
    {
        if (PreloadName != "")
        {
            StartCoroutine(LoadScene());
        }
    }

    public void PreloadScene(string name, bool allowActivation = false)
    {
        if (PreloadName != name)
        {
            PreloadName = name;
            StartCoroutine(LoadScene());
        }
        if(allowActivation)
        {
            AllowActivation();
        }
    }

    public void AllowActivation()
    {
        async.allowSceneActivation = true;
    }

    private IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync(PreloadName, LoadSceneMode.Single);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }

        Debug.Log("Finished loading" + PreloadName);
    }
}
