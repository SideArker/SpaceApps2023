using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct QuestInfo
{
    public Sprite sprite;
    [TextArea(4, 10)] public string desc;
}

public class InfoScreen : MonoBehaviour
{
    public static InfoScreen Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject vanish;
    public Sprite sprite;
    public string desc;

    [SerializeField] Image spriteRenderer;
    [SerializeField] TMP_Text descText;

    public void Setup()
    {
        spriteRenderer.sprite = sprite;
        descText.text = desc;
    }
    public void Show()
    {
        GetComponent<Image>().enabled = true;
        vanish.SetActive(true);
    }
}
