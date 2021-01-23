/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class DeadDialoueChanger : MonoBehaviour {


    
    void Start()
    {
        ShowDialogue sd = GetComponent<ShowDialogue>();

        if(PlayerInformation.currentlvl != "")
        {
            int t = PlayerInformation.timesDied;
            if (t == 0)
            {
                sd.dialogName = "dead";
            }
            else
            {
                sd.dialogName = "dead2";
            }

            PlayerInformation.timesDied++;
        }

    }
    
}
