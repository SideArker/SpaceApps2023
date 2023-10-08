using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : MonoBehaviour
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
        Observer.Instance.RemoveListener();

        Destroy(gameObject);
    }
}
