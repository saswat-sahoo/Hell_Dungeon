using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritedyn : MonoBehaviour
{
    Sprite currentSprite;
    BoxCollider2D coll;
    SpriteRenderer spr;

    void Start()
    {
        coll = gameObject.GetComponentInChildren<BoxCollider2D>();
        spr = gameObject.GetComponentInChildren<SpriteRenderer>();
        UpdateCollider();
    }

    void Update()
    {
        if (currentSprite != spr.sprite)
        {
            currentSprite = spr.sprite;
            UpdateCollider();
        }
    }

    void UpdateCollider()
    {
        coll.size = spr.size;
        //coll.offset = spr.sprite.bounds.center;

    }
}

