using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static int sceneId;
    [SerializeField] Animator anim;
    float secondsToWait = 1f;

    IEnumerator LoadScene()
    {

        yield return new WaitForSeconds(secondsToWait);

        AsyncOperation loadingAsync = SceneManager.LoadSceneAsync(sceneId);
        loadingAsync.allowSceneActivation = false;
        
        while (loadingAsync.progress < .9f) yield return null; 
        anim.Play("FadeOut");
        while (!FadeFinished.fadeFinish) yield return null;
        loadingAsync.allowSceneActivation = true;

        FadeFinished.fadeFinish = false;
            
    }

    private void Start()
    {
        anim.Play("FadeIn");
        StartCoroutine(LoadScene());
    }
}
