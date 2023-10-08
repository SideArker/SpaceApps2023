using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] Timer timer;
    [SerializeField] int questID;
    bool foundMine;
    private void Start()
    {
        timer.StartTimer();
    }


    public void OnEnd()
    {
        SelectionController.Instance.ChangeButtonsState(true);
        Geologist.Instance.RemoveListener();

        Collider2D[] hits = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);

        for (int i = 0; i < hits.Length; i++)
        {
            var mineable = hits[i].gameObject.GetComponent<Mineable>();
            if (mineable) { mineable.Discover(); foundMine = true; }
        }


        if(foundMine) QuestController.instance.ChangeQuestState(questID);
        Destroy(gameObject);
    }
}
