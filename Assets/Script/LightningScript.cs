/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class LightningScript : MonoBehaviour {

    public float minSize = 25f, maxSize = 35f, minInt = 0.75f, maxInt = 1.25f, speed = 5;

    Light light;

    Transform player;

    void Start()
    {
        light = GetComponent<Light>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        if(Vector2.Distance(transform.position,player.position) < 10)
        {
            light.enabled = true;
            float sVal = Random.Range(minSize, maxSize);
            float iVal = Random.Range(minInt, maxInt);

            light.spotAngle = Mathf.Lerp(light.spotAngle, sVal, speed * Time.deltaTime);
            light.intensity = Mathf.Lerp(light.intensity, iVal, speed * Time.deltaTime);
        }
        else
        {
            light.enabled = false;
        }
    }
}
