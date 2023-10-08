using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pomp : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] int questID;
    private void Start()
    {
        timer.StartTimer();
    }


    public void OnEnd()
    {
        QuestController.instance.ChangeQuestState(questID);

        SelectionController.Instance.ChangeButtonsState(true);
        Diver.Instance.RemoveListener();

        Destroy(gameObject);
    }
}
