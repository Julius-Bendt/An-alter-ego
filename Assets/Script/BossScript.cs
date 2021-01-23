using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BossScript : MonoBehaviour {

    Enemy e;

    public GameObject sight;

    public List<UserdataEvents> onDead = new List<UserdataEvents>();

    void Start ()
    {
        e = GetComponent<Enemy>();
        e.enabled = true;

        GetComponent<BoxCollider2D>().enabled = true;

        GetComponent<Rigidbody2D>().gravityScale = 1;

        e.target = GameObject.FindGameObjectWithTag("Player");


        sight.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if(e.health <= 0)
        {
            for(int i = 0; i < onDead.Count; i++)
            {
                BaseEventData eventData = new BaseEventData(EventSystem.current);
                onDead[i].theEvent.Invoke(eventData);
            }
            
        }
	}


    public void setAnimToDeath()
    {
        GetComponent<Animator>().SetTrigger("death");
    }
}
