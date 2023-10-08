using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    [SerializeField] int startMinutes;
    [SerializeField, Range(0,59)] int startSeconds;
    public TMP_Text currentTimeText;
    public UnityEvent onTimerEnd;
    private void Start()
    {
        currentTime = startMinutes * 60 + startSeconds;
    }
    private void Update()
    {
        if(timerActive)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                timerActive = false;
                Start();
                print("Timer Finished");
                onTimerEnd.Invoke();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    [Button]
    public void StartTimer()
    {
        timerActive = true;
        currentTimeText.gameObject.SetActive(true);
    }
    [Button]
    public void StopTimer()
    {
        timerActive = false;
    }
}
