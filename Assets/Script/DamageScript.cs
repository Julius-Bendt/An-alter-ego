/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

    public float timer, cooldown;


	void OnTriggerEnter2D(Collider2D o)
    {
        if(o.GetComponent<Character>() != null)
        {
            timer = 0;

            if(o.GetComponent<Player_ballon>() != null)
            {
                o.GetComponent<Player_ballon>().StartCoroutine(o.GetComponent<Player_ballon>().TakeDamage());
                Destroy(this);
            }
            else
            {
                o.GetComponent<Character>().StartCoroutine(o.GetComponent<Character>().TakeDamage());
            }

            Debug.Log("Damaged " + o.gameObject.name + ".");
        }
        
    }

    void OnTriggerStay2D(Collider2D o)
    {
        if (o.GetComponent<Character>() != null)
        {
            if (timer > cooldown)
            {
                timer = 0;

                o.GetComponent<Character>().StartCoroutine(o.GetComponent<Character>().TakeDamage());

                Debug.Log("Damaged " + o.gameObject.name + ".");


            }

            timer += Time.deltaTime;
        }
           
    }

    void OnTriggerExit2D(Collider2D o)
    {

    }
}
