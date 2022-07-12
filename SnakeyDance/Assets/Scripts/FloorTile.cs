using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : Floor
{
    [SerializeField] private Sprite arrowSprite;

    
    void Update()
    {
        if(roomNumber == 2) this.GetComponent<SpriteRenderer>().sprite = arrowSprite;
        if(roomNumber == 0) this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        else this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
