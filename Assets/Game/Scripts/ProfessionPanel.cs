using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class ProfessionPanel : MonoBehaviour
{
    public Color panelColor;
    public Sprite icon;
    public string name;
    public int count;
    public GameObject prefabWithScript;
    public UnityEvent onActivate;
    Image panel;
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text Count;
    private void Start()
    {
        panel = GetComponent<Image>();
        Init(); 
    }
    private void Init()
    {
        panel.color = panelColor;
        iconImage.sprite = icon;
        Count.text = count.ToString();
        if(prefabWithScript) Instantiate(prefabWithScript);
    }
    public void OnBtnClick()
    {
        onActivate.Invoke();
    }
    public void TEST()
    {
        print("test");
    }
}
