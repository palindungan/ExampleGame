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
            // Debug.Log("+" + pesosAmount + " pesos!");
            string msg = "+" + pesosAmount + " pesos!";
            GameManager.instance.ShowText(msg, 25, Color.yellow, transform.position, Vector3.up * 25, 1.0f);
        }
    }
}
