/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Axe : MonoBehaviour {

    Rigidbody2D rig;
    public int dir = 1;

    public int speed, rotationSpeed = 25;

    public GameObject parrent;


    List<GameObject> ObjectsNotToCollideWith = new List<GameObject>();

    float timer, duration = 1.5f;


	void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Vector2.right * dir * speed);


        for(int i = 0; i < parrent.transform.childCount; i++)
        {
            ObjectsNotToCollideWith.Add(parrent.transform.GetChild(i).gameObject);
        }

        ObjectsNotToCollideWith.Add(parrent);


       

        if (dir == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

	}
	
	void Update () {
        rig.rotation += rotationSpeed * -dir;

        timer += Time.deltaTime;

        if(timer >= duration)
        {
            Destroy(gameObject, 1f);
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            duration = 99999;   
        }
	}

    public void OnTriggerEnter2D(Collider2D o)
    {
        for(int i = 0; i < ObjectsNotToCollideWith.Count; i++)
        {
            if (ObjectsNotToCollideWith[i].name == o.gameObject.name)
                return;
        }

        if (o.isTrigger)
            return;


        Destroy(gameObject);
    }

}
