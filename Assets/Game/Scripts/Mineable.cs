using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
    [SerializeField] Sprite OreSprite;
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
            rend.sprite = OreSprite;
        }
    }
}
