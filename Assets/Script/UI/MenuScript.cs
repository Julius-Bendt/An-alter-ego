/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public menuScript_list[] menu_list;
	
	void Update ()
    {
	    for(int i = 0; i < menu_list.Length; i++)
        {
            if (Input.GetKeyDown(menu_list[i].key))
            {
                menu_list[i].obj.SetActive(!menu_list[i].obj.activeSelf);
                
            }
        }
	}
}

[System.Serializable]
public class menuScript_list
{
    public string name;
    public GameObject obj;
    public KeyCode key;
}
