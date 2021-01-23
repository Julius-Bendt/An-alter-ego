/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class dwarfDoor : MonoBehaviour {

    bool isOpen;

    public Sprite closed, opened;

    Collider2D c;
    SpriteRenderer r;

    void Start()
    {
        c = GetComponent<BoxCollider2D>();
        r = GetComponent<SpriteRenderer>();
    }

	public void UpdateState()
    {
        c.isTrigger = !c.isTrigger;

        if(isOpen)
        {
            r.sprite = closed;
        }
        else
        {
            r.sprite = opened;
        }

        isOpen = !isOpen;
    }
}
