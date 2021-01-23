using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorLerp : MonoBehaviour {

    public Color target;
    public float speed;

    public Text t;
	
	// Update is called once per frame
	void Update () {
        t.color = Color.Lerp(t.color, target, speed * Time.deltaTime);
	}
}
