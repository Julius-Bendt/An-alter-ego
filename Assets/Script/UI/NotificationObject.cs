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

public class NotificationObject : MonoBehaviour {

    static Text t;

    static Color startColor, fadeTo;

    static bool fade;

    public float speed = 2.5f;

    public static string currentText;

    private static float ttc, currenttime;

    void Start()
    {
        t = GetComponent<Text>();
        startColor = t.color;
        fadeTo = Color.clear;

        t.color = fadeTo;
    }

    void Update()
    {
        if(fade)
        {
            t.color = Color.Lerp(t.color, fadeTo, speed * Time.deltaTime);

            if(t.color == fadeTo)
            {
                fade = false;
            }
        }

        if(ttc > 0.01)
        {
            currenttime += Time.deltaTime;

            if(ttc < currenttime)
            {
                Close();
            }
        }
    }

    public static void ChangeText(string text,float timeTillClose = 0)
    {
        Open();
        ttc = timeTillClose;
        t.text = currentText = text; 
        
    }

    public void ChangeTextFromInspector(string text)
    {
        ChangeText(text,100000f);
    }

    public void close()
    {
        Close();
    }


    public static void Close()
    {
        fade = true;
        currenttime = 0;
        fadeTo = Color.clear;
    }

    public static void Open()
    {
        fade = true;
        fadeTo = startColor;
    }
}
