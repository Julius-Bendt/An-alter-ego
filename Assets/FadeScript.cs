using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FadeScript : MonoBehaviour {

    public Color fadeTo;

    public Image image;

    public SpriteRenderer render;

    public float speed = 2;

    public EventTrigger.TriggerEvent whenAlphaIs;

    public float alpha;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (render != null)
        {
            render.color = Color.Lerp(render.color, fadeTo, speed * Time.deltaTime);

            if(render.color.a >= alpha)
            {
                BaseEventData data = new BaseEventData(EventSystem.current);
                whenAlphaIs.Invoke(data);
            }
        }
            

        if (image != null)
        {
            image.color = Color.Lerp(image.color, fadeTo, speed * Time.deltaTime);

            if (image.color.a <= alpha)
            {
                BaseEventData data = new BaseEventData(EventSystem.current);
                whenAlphaIs.Invoke(data);
            }
        }
           

       
    }
}
