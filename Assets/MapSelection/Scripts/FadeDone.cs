using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeDone : StateMachineBehaviour
{
    [SerializeField] int sceneId;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        SceneManager.LoadScene(sceneId);
    }
}
