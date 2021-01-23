    /**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class SetNotificationText : MonoBehaviour {

    public string text;

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag == "Player")
        {
            NotificationObject.ChangeText(text);
        }
    }

    void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player" && NotificationObject.currentText == text)
        {
            NotificationObject.ChangeText("");
        }
    }

    public void ChangeText(string text)
    {
        this.text = text;
    }

    public void open()
    {
        ChangeText(text);
    }
}
