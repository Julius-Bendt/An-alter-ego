using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class drunkScript : MonoBehaviour {

     MotionBlur mb;
     Vortex v;

    SunShafts ss;

    float duration, drunk_timer, timer;

    Character p;

    bool setAngleToMin = false, itenUp = true;

	// Use this for initialization
	void Start ()
    {
        v = GetComponent<Vortex>();
        v.enabled = false;

        mb = GetComponent<MotionBlur>();
        mb.enabled = false;

        ss = GetComponent<SunShafts>();

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

    }

    void Update()
    {
        drunk_timer += Time.deltaTime;

        if(drunk_timer > duration)
        {
            OnFinish();

        }
        else
        {

            timer = Mathf.Clamp(timer + Time.deltaTime, 0.0f, 1.0f / 50);

            SetVortex(timer);
            SetSunShine(timer);
        }
    }
	
	public  void SetDrunk(float time)
    {
        duration = time;
        drunk_timer = 0;

        mb.enabled = true;
        v.enabled = true;
    }

    void SetVortex(float timer)
    {
        //Update vortex to give it a more "realistic" looking.
        int dir = p.dir;

        if (dir == 1)
            v.center = new Vector2(0.85f, 0.3f);
        else if (dir == -1)
            v.center = new Vector2(0.25f, 0.3f);

        if (setAngleToMin)
        {
            v.angle = Mathf.Lerp(v.angle, -250, 0.5f * timer);

            if (v.angle <= -240)
            {
                setAngleToMin = false;
            }
        }
        else
        {
            v.angle = Mathf.Lerp(v.angle, 250, 0.5f * timer);

            if (v.angle >= 240)
            {
                setAngleToMin = true;
            }
        }
    }

    void SetSunShine(float timer)
    {
        //Update sun to give it a more "realistic" looking.


        if (itenUp)
        {
            ss.sunShaftIntensity = Mathf.Lerp(ss.sunShaftIntensity, 10f, 0.5f * timer);

            if (ss.sunShaftIntensity >= 9.5f)
                itenUp = false;

        }
        else
        {
            ss.sunShaftIntensity = Mathf.Lerp(ss.sunShaftIntensity, 0.5f, 0.5f * timer);

            if (ss.sunShaftIntensity <= 1f)
                itenUp = true;
        }
    }

    void OnFinish()
    {
        mb.enabled = false;
        v.enabled = false;
        ss.sunShaftIntensity = 1.5f;
    }
}
