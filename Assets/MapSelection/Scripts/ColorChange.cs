using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] Color baseColor;
    [SerializeField] Color litColor;

    public void ColorSwitch(TMP_Text text)
    {
        text.color = text.color == baseColor ? litColor : baseColor;
    }
}
