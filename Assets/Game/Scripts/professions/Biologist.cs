using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Biologist : MonoBehaviour
{
    [SerializeField] Button btn;
    [SerializeField] GameObject prefab;
    public static Biologist Instance { get; private set; }
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
        SelectionController.Instance.onClick.AddListener(Examinate);
        SelectionController.Instance.ChangeButtonsState(false);
    }
    public void Examinate()
    {
        print("XD");
        var posTrans = SelectionController.Instance.sender;
        Instantiate(prefab, posTrans);
    }

    public void RemoveListener()
    {
        print("REMOVE SCANNER");
        SelectionController.Instance.onClick = new UnityEvent();
    }
}
