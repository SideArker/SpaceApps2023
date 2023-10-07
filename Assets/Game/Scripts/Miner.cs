using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] Drill drill;
    [SerializeField] float drillSpeed = 5;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Timer timer;
    bool timerStarted = false;

    private void Start()
    {
        Engineer.isMining = true;
        timer = GetComponent<Timer>();
        lineRenderer.SetPosition(0, new Vector3(transform.position.x + 0.07f, transform.position.y));
    }
    private void Update()
    {
        if (!drill.IsTrigger)
        {
            var newPos = Vector3.down * drillSpeed * Time.deltaTime;
            lineRenderer.SetPosition(1, new Vector3(transform.position.x + 0.07f, drill.transform.position.y + newPos.y));
            drill.transform.position += newPos;
            if(drill.transform.position.y <= -18)
            {
                Engineer.isMining = false;
                Destroy(gameObject);
            }
        }
        else if(!timerStarted)
        {
            timer.currentTimeText.gameObject.SetActive(true);
            timer.StartTimer();
            timerStarted = true;
        }
    }

    public void EndDrill()
    {
        Engineer.isMining = false;
        Destroy(gameObject);
    }
}
