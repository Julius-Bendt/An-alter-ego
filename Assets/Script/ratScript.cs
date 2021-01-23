/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class ratScript : MonoBehaviour {

    bool a = true;

	void Start () {
        PlayerInformation.enemyInLevel++;
	}
	
    //if dead
    void Update()
    {
        if(GetComponent<Enemy>().health <= 0 && a)
        {
            a = false;
            PlayerInformation.enemyInLevel--;
        }
    }

}
