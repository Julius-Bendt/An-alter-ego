/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class ShowDialogue : MonoBehaviour {


    public float maxDistance;

    public Transform player;

    public string dialogName;

    public string notificationText;

    Dialog d;

    void Start()
    {
        d = GameObject.FindGameObjectWithTag("Scripts").GetComponent<Dialog>();
    }

	void Update ()
    {
	    if(Vector2.Distance(transform.position,player.position) < maxDistance)
        {
            NotificationObject.ChangeText(notificationText,0);

            if(Input.GetKeyDown(KeyCode.E))
            {
                d.StartDialouge(dialogName);
                NotificationObject.Close();
            }
        }
        else
        {
            if(NotificationObject.currentText == notificationText)
            {
                NotificationObject.Close();
            }
        }
	}

    public void ChangeDialogName(string newName)
    {
        dialogName = newName;
    }
}
