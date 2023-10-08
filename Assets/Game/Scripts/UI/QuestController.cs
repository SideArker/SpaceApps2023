using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public static QuestController instance;
    [SerializeField] bool[] questState = new bool[5];
    [SerializeField] GameObject[] questObjects = new GameObject[5];
    [SerializeField] UnityEvent OnGameWin;
    [SerializeField] InfoScreen infosc;
    [SerializeField] Image vanisher;
    public QuestInfo[] questInfos;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator waitUntilInfoClosed()
    {
        while(infosc.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
            OnGameWin.Invoke();
        }
    }


    [Button]
    public void ChangeQuestState(int questID)
    {
        questState[questID] = true;
        questObjects[questID].GetComponent<Toggle>().isOn = true;
        questObjects[questID].GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;

        Time.timeScale = 0;
        UIStopWatch.Instance.stopwatch.Stop();
        infosc.sprite = questInfos[questID].sprite;
        infosc.desc = questInfos[questID].desc;
        infosc.Setup();
        infosc.Show();

        if (questState.Any(x => x == false)) return;

        // All quests completed

        Debug.Log("Quests completed. Mision finished");
        StartCoroutine(
                waitUntilInfoClosed());
    }

    public void TimeScale1()
    {
        Time.timeScale = 1;
        UIStopWatch.Instance.stopwatch.Start();
        vanisher.enabled = false;
    }
}
