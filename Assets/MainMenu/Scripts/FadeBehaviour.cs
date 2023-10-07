using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum fadeBehaviourType
{
    SceneChange,
    Entry
}

public class FadeBehaviour : StateMachineBehaviour
{
    [SerializeField] fadeBehaviourType fadeType;
    [SerializeField] int sceneId;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        if(fadeType == fadeBehaviourType.SceneChange) SceneManager.LoadScene(sceneId);
        else
        {
            animator.gameObject.SetActive(false);
        }
    }
}
