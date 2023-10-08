using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum TypeOfTile
{
    idle = 0,
    mineable = 1,
    surface = 2,
    liquid = 3
}
public class SelectionController : MonoBehaviour
{
    public List<SelectionScript> mineableTiles;
    public List<SelectionScript> surfaceTiles;
    public List<SelectionScript> liquidTiles;
    public Transform sender;
    public UnityEvent onClick;
    public static SelectionController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeButtonsState(bool state)
    {
        Engineer.Instance.ChnageBtnState(state);
        Geologist.Instance.ChnageBtnState(state);
        Biologist.Instance.ChnageBtnState(state);
        Observer.Instance.ChnageBtnState(state);
        Diver.Instance.ChnageBtnState(state);
    }
    public void ShowTilesSelection(TypeOfTile tot)
    {
        print("show");
        List<SelectionScript> list = new List<SelectionScript>();
        switch (tot)
        {
            case TypeOfTile.mineable:
                list = mineableTiles;
                break;
            case TypeOfTile.surface:
                list = surfaceTiles;
                break;
            case TypeOfTile.liquid:
                list = liquidTiles;
                break;
            default:
                break;
        }
        foreach (var item in list)
        {
            item.ShowSelection();
        }
    }
    public void HideTilesSelection(TypeOfTile tot)
    {
        List<SelectionScript> list = new List<SelectionScript>();
        switch (tot)
        {
            case TypeOfTile.mineable:
                list = mineableTiles;
                break;
            case TypeOfTile.surface:
                list = surfaceTiles;
                break;
            case TypeOfTile.liquid:
                list = liquidTiles;
                break;
            default:
                break;
        }
        foreach (var item in list)
        {
            item.HideSelection();
        }
    }
}
