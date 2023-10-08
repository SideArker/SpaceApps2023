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

    private void Awake()
    {
        instance = this;
    }


    [Button]
    public void ChangeQuestState(int questID)
    {
        questState[questID] = true;
        questObjects[questID].GetComponent<Toggle>().isOn = true;
        questObjects[questID].GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;

        if (questState.Any(x => x == false)) return;

        // All quests completed

        Debug.Log("Quests completed. Mision finished");

        OnGameWin.Invoke();

    }
}
