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

public class TriggerSystem : MonoBehaviour {

    public string tag = "Player";

    public EventTrigger.TriggerEvent OnEnter;

    public EventTrigger.TriggerEvent OnExit;

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag.ToLower() == tag.ToLower())
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);

            OnEnter.Invoke(eventData);
        }
    }

    void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag.ToLower() == tag.ToLower())
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            OnExit.Invoke(eventData);
        }
    }
}
