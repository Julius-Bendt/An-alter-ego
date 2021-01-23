/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestWindow_UI : MonoBehaviour {

    public Text title, desc;

    private static Text _title, _desc;

    void Start()
    {
        _title = title;
        _desc = desc;

        UpdateQuestWindow("Eye for an eye", "So, the old man told me his son was beat up by this guy. Its my job to find him and beat him up");
    }

    public static void UpdateQuestWindow(string theTitle,string theDesc)
    {
        _title.text = theTitle;
        _desc.text = theDesc;
    }
}
