/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class dieScript : MonoBehaviour {

    public GameObject[] disable;

	void Start () {
	    for(int i = 0; i < disable.Length; i++)
        {
            disable[i].SetActive(false);
        }
	}
	
	
}
