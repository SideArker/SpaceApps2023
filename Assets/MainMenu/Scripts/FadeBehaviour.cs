using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBehaviour : StateMachineBehaviour
{

    [SerializeField] int sceneId;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        SceneManager.LoadScene(sceneId);
    }
}
