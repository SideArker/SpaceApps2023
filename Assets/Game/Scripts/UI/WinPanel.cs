using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TMP_Text timeTakenText;
    private void Start()
    {
        timeTakenText.text = $"{UIStopWatch.Instance.stopwatch.Elapsed.Minutes}:{UIStopWatch.Instance.stopwatch.Elapsed.Seconds}";
    }
}
