using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomp : MonoBehaviour
{
    [SerializeField] Timer timer;
    private void Start()
    {
        timer.StartTimer();
    }


    public void OnEnd()
    {
        SelectionController.Instance.ChangeButtonsState(true);
        Diver.Instance.RemoveListener();

        Destroy(gameObject);
    }
}
