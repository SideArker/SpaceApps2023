using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinate : MonoBehaviour
{
    [SerializeField] Timer timer;
    private void Start()
    {
        timer.StartTimer();
    }


    public void OnEnd()
    {
        SelectionController.Instance.ChangeButtonsState(true);
        Biologist.Instance.RemoveListener();

        Destroy(gameObject);
    }
}
