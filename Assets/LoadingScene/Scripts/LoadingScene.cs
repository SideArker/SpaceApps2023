using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static int sceneId;
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text loading_text;
    float secondsToWait = 1f;

    IEnumerator LoadScene()
    {

        yield return new WaitForSeconds(secondsToWait);

        AsyncOperation loadingAsync = SceneManager.LoadSceneAsync(sceneId);
        loadingAsync.allowSceneActivation = false;
        
        while (loadingAsync.progress < .9f) 
        {
            loading_text.text = $"Loading... \n({loadingAsync.progress * 100}% / 100%)";
            yield return new WaitForSeconds(0.1f);

        };
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
