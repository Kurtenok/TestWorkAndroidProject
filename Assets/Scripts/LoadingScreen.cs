using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    // Start is called before the first frame update
    public void Load(int buildIndex)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Loading(buildIndex));
    }
    IEnumerator Loading(int buildIndex)
    {
        AsyncOperation loadAsync=SceneManager.LoadSceneAsync(buildIndex);
        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            progressSlider.value=loadAsync.progress;
            if(loadAsync.progress>= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1.5f);
                loadAsync.allowSceneActivation=true;   
            }
            yield return null;
        }
    }
}
