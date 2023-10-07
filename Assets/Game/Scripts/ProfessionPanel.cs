using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProfessionPanel : MonoBehaviour
{

    [SerializeField] TMP_Text Count;
    [SerializeField] Transform damagedIcon;
    [SerializeField] int id;
    int count;
    bool isDamaged = false;
    private void Start()
    {
        SetCountOfPeople(TeamSelector.GetCountOfAstronaut(id));
    }
    public void SetCountOfPeople(int value)
    {
        count = value;
        Count.text = count.ToString();
    }
    public void Damage()
    {
        isDamaged = true;
        damagedIcon.gameObject.SetActive(true);
    }
}
