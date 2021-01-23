/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private Collider2D other;

	void Awake ()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
	}
	
}
