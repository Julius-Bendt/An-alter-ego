using UnityEngine;
using System.Collections;

public class seagullSpawner : MonoBehaviour {

    public GameObject seagull;

    float timer;
	
	void Update () {

        timer += Time.deltaTime;

        if(timer > 8f)
        {
            spawn();
            timer = 0;
        }

	}


    void spawn()
    {
        Vector3 pos = new Vector3(transform.position.x, Random.Range(-3, 4));
        GameObject g = Instantiate(seagull, pos, Quaternion.identity) as GameObject;
    }
}
