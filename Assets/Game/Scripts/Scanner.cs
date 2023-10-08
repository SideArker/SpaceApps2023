using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Timer timer;
    private void Start()
    {
        timer.StartTimer();
    }

    public void OnEnd()
    {
        Geologist.Instance.ChnageBtnState(true);
        Geologist.Instance.RemoveListener();
        Destroy(gameObject);
    }
}
