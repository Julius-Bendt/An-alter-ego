/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class falling_boulders_smash : MonoBehaviour {

    Rigidbody2D r;
    DamageScript d;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        d = GetComponent<DamageScript>();
    }

	void Update () {

	    if(r.velocity.magnitude < 0)
        {
            Destroy(d);
            Destroy(this);
        }


    }

}
