using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
{
    [SerializeField] Timer timer;
    private void Start()
    {
        timer.StartTimer();
    }


    public void OnEnd()
    {
        Observer.Instance.ChnageBtnState(true);
        Observer.Instance.RemoveListener();

        Destroy(gameObject);
    }
}
