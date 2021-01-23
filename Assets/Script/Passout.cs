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

public class Passout : MonoBehaviour {

    [SerializeField]
    RawImage image;

    [SerializeField]
    Text t;

    float timer = 3f, duration = 4f;

    public float lerpTime;

    int current = 0; 

    public string[] text;

    public bool lerp = false;

    public string sceneName = "deadcity";

    bool finishedLerp;


    public void Start()
    {
        PlayerInformation.currentlvl = "";
        if(!lerp)
            image.color = Color.black;
        else
        {
            image.color = Color.clear;
        }
        t.enabled = true;
    }

	public void Update()
    {
        if (lerp)
        {
            image.color = Color.Lerp(image.color, Color.black, lerpTime * Time.deltaTime);

            if (image.color.a > 0.9)
            {
                finishedLerp = true;
            }

            if (image.color.a >= 0.99)
            {
                lerp = false;
            }

        }
        else
        { finishedLerp = true; }

        if(finishedLerp)
        {
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                if (current >= text.Length)
                {
                    Application.LoadLevel(sceneName);
                    return;
                }

                timer = 0;
                t.text = text[current];
                current++;

            }
        }
       
    }



}
