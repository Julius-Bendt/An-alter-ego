using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_ballon : MonoBehaviour {

    public Sprite s;

    public float force, max, speed;

     Image[] healthbar;

     GameObject  passout;
    ParticleSystem blood;

    BoxCollider2D org, init;

    public GameObject[] ballons;

    int health;

    float  deadTimer, respawnCooldown;

    Rigidbody2D r;

    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = s;
        //transform.localScale = new Vector3(2, 2, 2);

        healthbar = GetComponent<Player>().healthbar;
        passout = GetComponent<Player>().passout;
        health = GetComponent<Player>().health;
        deadTimer = GetComponent<Player>().deadTimer;
        respawnCooldown = GetComponent<Player>().respawnCooldown;
        blood = GetComponent<Player>().blood;

        GetComponent<Player>().enabled = false;
        GetComponent<Animator>().enabled = false;

        org = GetComponent<BoxCollider2D>();

        org.enabled = false;

       init = gameObject.AddComponent<BoxCollider2D>();

        r = GetComponent<Rigidbody2D>();

        Camera.main.GetComponent<CameraScript>().autoSetDir = false;
        Camera.main.GetComponent<CameraScript>().dir = -1;


        for(int i = 0; i < ballons.Length; i++)
        {
            //ballons[i].transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            ballons[i].SetActive(true);
        }
    }

    void Update()
    {
        if(health > 0)
        {
           
                if (r.velocity.magnitude <= max)
                {
                    if(Input.GetMouseButton(0))
                    {
                        r.AddForce(Vector2.up * force);
                    }
                    r.AddForce(-Vector2.right * speed);
                }
                    
                    
            


            int b = health / 10;


            for (int i = 0; i < ballons.Length; i++)
            {
                if (i + 1 > b)
                {
                    ballons[i].SetActive(false);
                }
            }

        }
        else
        {
            die();
        }
    }

    void die()
    {
        passout.SetActive(true);
        deadTimer += Time.deltaTime;

        if (deadTimer > respawnCooldown / 2)
        {
            passout.GetComponent<RawImage>().color = Color.black;
            passout.GetComponentInChildren<Text>().text = "You died";

        }

        if (deadTimer > respawnCooldown)
        {
            PlayerInformation.health = 50;
            PlayerInformation.currentlvl = Application.loadedLevelName;
            Application.LoadLevel("deadcity");
        }
    }

    void UpdateHealthbar()
    {

        if (healthbar[0] == null)
            return;

        int h = health / 10;


        for (int i = 0; i < healthbar.Length; i++)
        {
            if (i + 1 > h)
            {
                healthbar[i].enabled = false;
            }
        }
    }

    public IEnumerator TakeDamage()
    {
        health -= 10;
        PlayerInformation.health = health;

        blood.Play();

        UpdateHealthbar();

        yield return null;

    }

    public void Disable()
    {
        PlayerInformation.health = health;
        transform.localScale = new Vector3(7, 7, 7);

        org.enabled = true;

        Destroy(init);

        GetComponent<Player>().enabled = true;
        GetComponent<Animator>().enabled = true;

        Camera.main.GetComponent<CameraScript>().autoSetDir = true;

        for (int i = 0; i < ballons.Length; i++)
        {
            ballons[i].SetActive(false);
        }

        this.enabled = false;
    }
}
