using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] Drill drill;
    [SerializeField] float drillSpeed = 5;
    [SerializeField] LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.SetPosition(0, new Vector3(transform.position.x + 0.07f, transform.position.y));
    }
    private void Update()
    {
        if (!drill.IsTrigger)
        {
            var newPos = Vector3.down * drillSpeed * Time.deltaTime;
            lineRenderer.SetPosition(1, new Vector3(transform.position.x + 0.07f, drill.transform.position.y + newPos.y));
            drill.transform.position += newPos;
        }
    }
}
