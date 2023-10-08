using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicController : MonoBehaviour
{
    [SerializeField] Sprite[] endings = new Sprite[3];
    [SerializeField] List<int> secondsForEndings = new List<int>();
    [SerializeField] Image ending;
    private void Start()
    {
        int timeTakenInSeconds = (int)UIStopWatch.Instance.stopwatch.Elapsed.TotalSeconds;

        if (timeTakenInSeconds < secondsForEndings[0]) ending.sprite = endings[0];
        if (timeTakenInSeconds < secondsForEndings[1]) ending.sprite = endings[1];
        if (timeTakenInSeconds > secondsForEndings[2]) ending.sprite = endings[2];



    }
}
