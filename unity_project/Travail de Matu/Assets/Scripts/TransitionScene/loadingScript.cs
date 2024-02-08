using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class loadingScript : MonoBehaviour
{   

    public GameObject loaderUI;
    public Slider progressSlider;

    public void LoadScene(int index) {
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public IEnumerator LoadScene_Coroutine(int index) {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;

        float progress = 0;

        while(!asyncOperation.isDone) {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f) {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    //public GameObject LoadingTheScene;
    //public Image LoadingBarFill;
    //
    //public void LoadScene(int sceneId)
    //{
    //    StartCoroutine(LoadSceneAsync(sceneId));
    //}
    //
    //IEnumerator LoadSceneAsync(int sceneId)
    //{
    //
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
    //
    //    LoadingTheScene.SetActive(true);
    //
    //    while (!operation.isDone)
    //    {
    //        float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
    //
    //        LoadingBar.fillAmount = progressValue;
    //
    //        yield return null;
    //   }
    //}
}
