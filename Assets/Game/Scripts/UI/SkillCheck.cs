using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillCheck : MonoBehaviour
{
    [SerializeField] float lerpDuration = 1f;

    [SerializeField] Slider skillcheckSlider;
    [SerializeField] Slider correctValueIndicator;

    [SerializeField] [Range(0f, .350f)] float rangeValue;

    public UnityEvent SkillCheckPass;
    float correctValue;

    bool stop = false;

    void Randomise()
    {
        correctValue = Random.Range(0f, 1f);
        lerpDuration = Random.Range(0.5f, 1.5f);

        correctValueIndicator.value = correctValue;
    }

    IEnumerator moveSliderValue()
    {
        stop = false;
        float timeElapsed = 0;

        while(timeElapsed < lerpDuration)
        {
            skillcheckSlider.value = Mathf.Lerp(skillcheckSlider.minValue, skillcheckSlider.maxValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;

            if (stop)
            {
                float stoppedValue = skillcheckSlider.value;

                Debug.Log("stopped at " + stoppedValue);
                Debug.Log("Range is between: " + (correctValue - rangeValue) + " - " + (correctValue + rangeValue));
                if(stoppedValue > correctValue - rangeValue && stoppedValue < correctValue + rangeValue)
                {
                    Debug.Log("invoke");
                    SkillCheckPass.Invoke();
                }
                break;
            }
        }
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
