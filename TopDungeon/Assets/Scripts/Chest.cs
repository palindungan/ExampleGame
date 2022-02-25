using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emtySprite;
    public int pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            GetComponent<SpriteRenderer>().sprite = emtySprite;
            Debug.Log("Grant " + pesosAmount + " pesos!");
        }

    }
}
