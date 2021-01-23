/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public float dir_offset = 3;

    public float speed, lerpSpeed = 2;

    public int dir;

    public bool shake, lerp;

    Color c;

    public bool autoSetDir = true;

    void Update () {

        if(lerp)
        {
            Fade();
        }

        if(!shake)
        {
            Follow();
        }
        else
        {
            Shake();
        }


	}

    void Follow()
    {

        if (autoSetDir)
        {
            int n_dir = target.GetComponent<Player>().dir;

            if (n_dir != 0)
            {
                dir = n_dir;
            }
        }

        Vector3 nPos = new Vector3(target.position.x + dir * dir_offset, target.position.y, target.position.z) + offset;

        if (speed >= 100)
        {
            transform.position = nPos;
            return;
        }

        transform.position = Vector3.LerpUnclamped(transform.position, nPos, speed * Time.deltaTime);
    }

    void Shake()
    {
        int x = Random.Range(-4,4), y = Random.Range(-4,4);

        int n_dir = target.GetComponent<Player>().dir;

        if (n_dir != 0)
        {
            dir = n_dir;
        }

        Vector3 nPos = new Vector3(target.position.x + x + dir * dir_offset, target.position.y + y, 0) + offset;

        if (speed >= 100)
        {
            transform.position = nPos;
            return;
        }

        transform.position = Vector3.LerpUnclamped(transform.position, nPos, speed * Time.deltaTime);
    }

    void Fade()
    {
        GetComponent<Camera>().backgroundColor = Color.Lerp(GetComponent<Camera>().backgroundColor, c, lerpSpeed * Time.deltaTime);

        if (GetComponent<Camera>().backgroundColor == c)
            lerp = false;
    }

    public void setShaking(bool val)
    {
        shake = val;

        Debug.Log("shake = " + shake);
    }


    public void setColorBlack()
    {
        lerp = true;
        this.c = Color.black;
    }

    public void setOffsetY(float y)
    {
        offset = new Vector3(offset.x, y, offset.z);
    }

    public void setOffsetX(float x)
    {
        offset = new Vector3(x, offset.y, offset.z);
    }

    public void changedir(int d)
    {
        dir = d;
    }

}
