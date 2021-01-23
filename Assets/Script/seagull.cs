using UnityEngine;
using System.Collections;

public class seagull : MonoBehaviour {

    Rigidbody2D r;

	// Use this for initialization
	void Start () {
        PlayerInformation.seagulls++;

        r = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(r.velocity.magnitude <= 2)
            r.AddForce(Vector2.right * 2);
	}

    void OnDestroy()
    {
        PlayerInformation.seagulls--;
    }
}
