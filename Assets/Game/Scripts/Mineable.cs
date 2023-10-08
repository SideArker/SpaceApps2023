using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
    [SerializeField] Sprite OreSprite;
    [SerializeField] Sprite NormalSprite;
    SpriteRenderer rend;
    public bool isVisible = false;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    [Button]
    public void Discover()
    {
        if(!isVisible)
        {
            isVisible = true;
            tag = "mineable";
            NormalSprite = rend.sprite;
            rend.sprite = OreSprite;
        }
        else {
            rend.sprite = NormalSprite; 
            isVisible = false;
            tag = "Untagged";
        }

    }
}
