/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public KeyCode key = KeyCode.E;

    public bool trigger = false;
    public float distance;

    public string sceneName;

    bool load;

    public Transform player;

    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    void Update()
    {
        if(!trigger)
        {
            load = false;

            float dest = Vector2.Distance(transform.position, player.position);

            if(dest <= distance)
            {
                load = true;
            }

        }

        if(load && Input.GetKeyDown(key))
        {
            Application.LoadLevel(sceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag == "Player" && trigger)
        {
            load = true;
        }

    }
    
    void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player" && trigger)
        {
            load = false;
        }
    }


}
