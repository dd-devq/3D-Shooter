using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LoadSceneManager : SingletonMono<LoadSceneManager>
{
    public void OnLoadScene(string sceneName, Action<object> callback)
    {
        StartCoroutine(LoadScene(new LoadSceneData { sceneName = sceneName, callback = callback }));
    }

    IEnumerator LoadScene(LoadSceneData loadSceneData)
    {
        yield return new WaitForSeconds(0.1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadSceneData.sceneName, LoadSceneMode.Single);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }

        if (loadSceneData.callback != null)
        {
            loadSceneData.callback(loadSceneData.sceneName + " done");
        }
    }
}

public class LoadSceneData
{
    public string sceneName;
    public Action<object> callback;
}