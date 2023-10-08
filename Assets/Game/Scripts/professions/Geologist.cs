using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Geologist : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] GameObject scanner;

    public static Geologist Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void ChnageBtnState(bool state)
    {
        btn.interactable = state;
    }
    public void Btn()
    {
        print("btn");
        SelectionController.Instance.ShowTilesSelection(TypeOfTile.surface);
        SelectionController.Instance.onClick.AddListener(SetScanner);
        SelectionController.Instance.ChangeButtonsState(false);
    }
    public void SetScanner()
    {
        print("setting  scan");
        var posTrans = SelectionController.Instance.sender;
        Instantiate(scanner, posTrans);
    }

    public void RemoveListener()
    {
        print("REMOVE SCANNER");
        SelectionController.Instance.onClick = new UnityEvent();
    }
}
