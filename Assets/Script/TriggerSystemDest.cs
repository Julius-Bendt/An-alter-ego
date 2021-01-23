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

public class TriggerSystemDest : MonoBehaviour {

    public Transform obj;

    public float dist;

    public KeyCode key = KeyCode.None;

    public EventTrigger.TriggerEvent OnEnter;

    public EventTrigger.TriggerEvent OnExit;

    bool entered;

    void Update()
    {
        if(Vector2.Distance(transform.position,obj.position) <= dist && !entered)
        {
            if(key != KeyCode.None)
            {
                if (Input.GetKeyDown(key))
                {
                    entered = true;
                    Enter();
                }
            }
            else
            {
                entered = true;
                Enter();
            }
            
            
        }
        else
        {
            if(entered)
            {
                entered = false;
                Exit();
            }
        }
    }

    void Enter()
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        OnEnter.Invoke(eventData);
    }

    void Exit()
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        OnExit.Invoke(eventData);
    }
}
