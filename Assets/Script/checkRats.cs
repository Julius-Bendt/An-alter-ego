/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class checkRats : MonoBehaviour {

    public ShowDialogue sd;

    int d = 1;

	public void CheckRatStatus()
    {
        Debug.Log("current rats: " + PlayerInformation.enemyInLevel);
        if(PlayerInformation.enemyInLevel <= 0)
        {
            d++;
            sd.dialogName = "dwarf_" + d;
        }
        else
        {
            sd.dialogName = "dwarf_morerats";
        }
    }
}
