using NaughtyAttributes;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    [SerializeField] int startMinutes;
    [SerializeField, Range(0,59)] int startSeconds;
    [SerializeField] HealthBar HealthBar;
    [SerializeField] int id;
    //public TMP_Text currentTimeText;
    public UnityEvent onTimerEnd;

    [SerializeField] float chanceForSkillCheck = 0.1f;
    bool onGoingSkillCheck = false;
    bool rollingSkillCheck = false;
    private void Start()
    {
        currentTime = startMinutes * 60 + startSeconds;
        HealthBar.maxMalue = currentTime;
    }

    public void ChanceForSkillCheck(float chance)
    {
        chanceForSkillCheck = chance;
    }

    IEnumerator SkillCheckTime()
    {
        rollingSkillCheck = true;

        float randomRoll = UnityEngine.Random.Range(0f, 1f);

        while (chanceForSkillCheck < randomRoll)
        {

            yield return new WaitForSeconds(1f);

            randomRoll = UnityEngine.Random.Range(0f, 1f);
        }

        SkillCheck.instance.SkillCheckStart();

        onGoingSkillCheck = true;

        // keep waiting for skill check

        while (!SkillCheck.instance.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }

        bool result = SkillCheck.instance.skillCheckResult;

        if(result)
        {
            Debug.Log("Positive skillcheck, no bad things happen");
        }
        else
        {
            Debug.Log("Bad skillcheck, you go back in time");

            currentTime += (startMinutes * 60 + startSeconds) * 0.3f;
        }
        
        onGoingSkillCheck = false;
        rollingSkillCheck = false;

        yield break;
    }


    private void Update()
    {
        if(timerActive && !onGoingSkillCheck)
        {
            currentTime -= Time.deltaTime * TeamSelector.GetCountOfAstronaut(id);
            HealthBar.value = currentTime;
            if (!rollingSkillCheck) 
            {
                //Debug.Log("h");
                StartCoroutine(SkillCheckTime());
            }

            if(currentTime <= 0)
            {
                timerActive = false;
                Start();
                print("Timer Finished");
                //currentTimeText.gameObject.SetActive(false);
                onTimerEnd.Invoke();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    [Button]
    public void StartTimer()
    {
        timerActive = true;
        //currentTimeText.gameObject.SetActive(true);
    }
    [Button]
    public void StopTimer()
    {
        timerActive = false;
    }
}
