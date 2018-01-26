using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    private Slider slider;

    public string NextScene;

    public string LoadingSceneName = "Loading";
    public string SliderName = "Slider";

    private AsyncOperation async;

    public bool BeginLoad = true;

    public GameObject menuCanvas;

    protected MenuLoader() { }

    private void Start()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == LoadingSceneName)
        {
            slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        }
    }

    private void Update()
    {
        if (BeginLoad)
        {
            if(NextScene != "")
            {
                StartCoroutine(loadScene(NextScene));
            }
            else
            {
                throw new System.Exception("YOU SUCK!!!!!!!! WHY TF IS NEXTSCENE NULL???");
            }
            BeginLoad = false;
        }
        if (slider && async != null)
        {
            slider.value = async.progress;
        }
    }

    private IEnumerator loadScene(string name)
    {
        async = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }

        if(menuCanvas)
        {
            menuCanvas.SetActive(true);
        }
    }

    public void LoadNextScene(string name = "")
    {
        if(name != "")
        {
            NextScene = name;
        }
        if (NextScene != "")
        {
            StartCoroutine(loadScene(NextScene));
        }
        else
        {
            throw new System.Exception("YOU SUCK!!!!!!!! WHY TF IS NEXTSCENE NULL???");
        }
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }
}
