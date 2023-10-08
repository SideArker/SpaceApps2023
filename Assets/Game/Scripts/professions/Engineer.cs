using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Engineer : MonoBehaviour
{
    public static bool isMining = false;
    [SerializeField] GameObject miner;
    [SerializeField] Button btn;
    public static Engineer Instance { get; private set; }
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
        SelectionController.Instance.onClick.AddListener(SetMiner);
    }
    public void SetMiner()
    {
        print("setting  miner");
        var posTrans = SelectionController.Instance.sender;
        Instantiate(miner, posTrans);
    }
    public void RemoveListener()
    {
        print("REMOVE MINER");
        SelectionController.Instance.onClick.RemoveAllListeners();
    }

}
