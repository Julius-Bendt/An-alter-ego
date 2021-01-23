/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public string Name, sceneName, text;
    public bool enterable = true;

    bool entered;

    void Update()
    {
        if(entered && Input.GetKeyDown(KeyCode.E) && enterable)
        {
            if (Application.CanStreamedLevelBeLoaded(sceneName))
                Application.LoadLevelAsync(sceneName);
            else
                Debug.Log(sceneName + " doesn't exists, and can't be loaded.");
        }
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            entered = true;
            NotificationObject.ChangeText(text);
        }
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            entered = false;
            NotificationObject.Close();
        }
    }

}
