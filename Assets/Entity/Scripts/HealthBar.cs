using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject Fill;

    public float value;
    public float maxMalue;
    void Start()
    {
    }

    void Update()
    {
        if (value < maxMalue)
        {
            Fill.transform.localScale = new Vector3(value / maxMalue, Fill.transform.localScale.y, Fill.transform.localScale.z);
            Color colorChange = Color.Lerp(Color.red, Color.green, value / maxMalue);
            Fill.GetComponentInChildren<SpriteRenderer>().color = colorChange;
        }
    }
}
