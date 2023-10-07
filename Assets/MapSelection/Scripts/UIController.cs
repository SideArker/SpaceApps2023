using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Color baseColor;
    [SerializeField] Color litColor;
    [SerializeField] Animator FadeIn;
    public void ColorSwitch(TMP_Text text)
    {
        text.color = text.color == baseColor ? litColor : baseColor;
    }

    private void Start()
    {
        FadeIn.gameObject.SetActive(true);
        FadeIn.Play("ScreenFadeIn");
    }
}
