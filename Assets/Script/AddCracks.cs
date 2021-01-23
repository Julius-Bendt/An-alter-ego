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

public class AddCracks : MonoBehaviour {

    public Sprite[] cracks;
    public Color[] BackgroundColor;

    public Image crackImage;
    public Camera camera;

    void Start () {

        int t = PlayerInformation.timesDied;

        if (t <= cracks.Length - 1)
        {
            crackImage.sprite = cracks[t];
            camera.backgroundColor = BackgroundColor[t];
        }
        else
        {
            crackImage.sprite = cracks[cracks.Length - 1];
            camera.backgroundColor = BackgroundColor[BackgroundColor.Length - 1];
        }

        if(t >= 9)
        {
            Application.LoadLevel("Gameover");
        }
    }
	
}
