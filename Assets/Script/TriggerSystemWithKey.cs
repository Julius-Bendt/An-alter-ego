/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class TriggerSystemWithKey : MonoBehaviour
{

    public string tag = "Player";

    public EventTrigger.TriggerEvent OnPressWhileInTrigger;

    public KeyCode key;

    bool entered;

    void Update()
    {
        if(entered && Input.GetKeyDown(key))
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);

            OnPressWhileInTrigger.Invoke(eventData);

            Debug.Log("triggered!");
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag == tag)
        {
            entered = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == tag)
        {
            entered = false;
        }
    }
}

