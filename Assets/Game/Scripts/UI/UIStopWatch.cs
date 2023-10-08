using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class UIStopWatch : MonoBehaviour
{
    public static UIStopWatch Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] TMP_Text text;

    public System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


    private void Start()
    {
        stopwatch.Start();
        StartCoroutine(Tick());
    }
    private IEnumerator Tick()
    {
        while(true)
        {
            text.text = $"{stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}";
            yield return new WaitForSeconds(1f);
        }
    }


}
