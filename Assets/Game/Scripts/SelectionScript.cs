using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    SpriteRenderer rend;
    Collider2D col;
    [SerializeField] TypeOfTile typeOfTile;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        rend.enabled = false;
        col.enabled = false;
        switch (typeOfTile)
        {
            case TypeOfTile.mineable:
                SelectionController.Instance.mineableTiles.Add(this);
                break;
            case TypeOfTile.surface:
                SelectionController.Instance.surfaceTiles.Add(this);
                break;
            case TypeOfTile.liquid:
                SelectionController.Instance.liquidTiles.Add(this);
                break;
            default:
                break;
        }
    }
    public void ShowSelection()
    {
        print("show selec");
        rend.enabled = true;
        col.enabled = true;
    }
    public void HideSelection()
    {
        rend.enabled = false;
        col.enabled = false;
    }

    private void OnMouseDown()
    {
        SelectionController.Instance.sender = transform;
        SelectionController.Instance.onClick.Invoke();
        SelectionController.Instance.HideTilesSelection(typeOfTile);

        
    }
}
