using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();


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
