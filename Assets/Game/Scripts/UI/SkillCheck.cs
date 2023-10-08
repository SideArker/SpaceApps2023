using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{
    public static SkillCheck instance;

    [SerializeField] float lerpDuration = 1f;

    [SerializeField] Slider skillcheckSlider;
    [SerializeField] Slider correctValueIndicator;
    [SerializeField] AudioSource click;

    [SerializeField] [Range(0f, .350f)] float rangeValue;

    public bool skillCheckResult { get; private set; }
    public bool isDone { get; private set; }
    float correctValue;

    bool stop = false;

    private void Awake()
    {
        instance = this;
    }

    void Randomise()
    {
        correctValue = Random.Range(0f, 1f);
        lerpDuration = Random.Range(1.5f, 2f);

        skillCheckResult = false;
        isDone = false;

        correctValueIndicator.value = correctValue;
    }

    IEnumerator moveSliderValue()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        stop = false;
        float timeElapsed = 0;

        while(timeElapsed < lerpDuration)
        {
            skillcheckSlider.value = Mathf.Lerp(skillcheckSlider.minValue, skillcheckSlider.maxValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;

            if (stop)
            {
                click.Play();
                float stoppedValue = skillcheckSlider.value;

                if(stoppedValue > correctValue - rangeValue && stoppedValue < correctValue + rangeValue)
                {
                    skillCheckResult = true;
                }
                else
                {
                    skillCheckResult = false;

                }
                break;
            }
        }
        isDone = true;
        skillcheckSlider.value = skillcheckSlider.maxValue;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield break;
    }
    public void SkillCheckStart()
    {
        Randomise();
        StartCoroutine(moveSliderValue());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !stop)  stop = true; 
    }
}
