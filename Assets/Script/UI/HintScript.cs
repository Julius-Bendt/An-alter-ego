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

public class HintScript : MonoBehaviour {

    public Text _text;
    public GameObject panel;

    public static Text t;
    public static GameObject p;

    void Start()
    {
        t = _text;
        p = panel;
    }

    public static void UpdateHint(string text)
    {
        t.text = text;
        p.SetActive(true);
    }

    public void UpdateHintFromInspector(string text)
    {
        UpdateHint(text);
    }
}
