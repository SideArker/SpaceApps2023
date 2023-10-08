using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TMP_Text timeTakenText;
    public void updateTimeTaken()
    {
        timeTakenText.text = "";
    }
}
