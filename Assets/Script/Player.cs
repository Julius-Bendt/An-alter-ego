/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Player : Character {

    Rigidbody2D rig;

    public GameObject axe, passout;

    // Jump region
    BoxCollider2D collider;
    const float skinWidth = .015f;

    [Range(3, 15)]
    public int rayCount = 4;

    float raySpacing;

    float rayLength = 0.05f;

    RaycastOrigins raycastOrigins;

    bool jump;

    public float jumpforce = 750;

    public LayerMask whatIsGround;

    public ParticleSystem blood;

    public Image[] healthbar;

    public float axeCooldown, respawnCooldown;

    float axeTimer;

    [HideInInspector]
    public float deadTimer;

    public AudioClip[] swings;
    public AudioClip walk;

    public GameObject walkPlayer, swingPlayer;

    bool guard;

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public override void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
        base.Start();
        collider = GetComponent<BoxCollider2D>();

        health = PlayerInformation.health;
        UpdateHealthbar();

        axeTimer = axeCooldown;

        attack = false;

        Dialog.windowOpen = false;

        l_dir = 1;
	}

    void Update()
    {


        if(!IsDead)
        {
            if (!takingDamage)
            {
                if(!Dialog.windowOpen)
                {
                    Move();
                    Jump();
                    Attack();
                    Guard();

                    if (Input.GetButtonDown("Throw"))
                    {
                        ThrowAxe();
                    }
                }

                axeTimer += Time.deltaTime;
            }
        }
        else //Dead
        {
            passout.SetActive(true);
            deadTimer += Time.deltaTime;

            if(deadTimer > respawnCooldown /2)
            {
                passout.GetComponent<RawImage>().color = Color.black;
                passout.GetComponentInChildren<Text>().text = "You died";
                
            }

            if(deadTimer > respawnCooldown)
            {
                PlayerInformation.health = 50;
                PlayerInformation.currentlvl = Application.loadedLevelName;
                Application.LoadLevel("deadcity");
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D o)
    {
        base.OnTriggerEnter2D(o);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0 && !attack)
        {
            dir = Mathf.FloorToInt(x);

            Debug.Log("dir: " + dir + " l_dir " + l_dir);


            if(-dir == l_dir)
            {
                Flip();
                l_dir = dir;
            }
            

            if(jump)
                walkPlayer.GetComponent<AudioSource>().enabled = true;

            if (rig.velocity.magnitude < currentSpeed)
                rig.AddForce(Vector2.right * currentSpeed * dir);
            Anim.SetFloat("speed", 1);
        }
        else
        {
            walkPlayer.GetComponent<AudioSource>().enabled = false;
            Anim.SetFloat("speed", 0);
        }


        
        if (rig.velocity.x > 8f)
            rig.velocity = new Vector2(8f, rig.velocity.y);




    }

    void Jump()
    {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < rayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * raySpacing * i, Vector2.up * rayLength, Color.red);

            Vector2 rayOrigin = raycastOrigins.bottomLeft;
            rayOrigin += Vector2.right * raySpacing * i;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -Vector2.up, rayLength, whatIsGround);

            if (hit)
            {
                jump = true;
            }
        }


        if (jump && Input.GetButton("Jump") && !attack)
        {
            jump = false;
            rig.AddForce(transform.up * jumpforce);

            

        }

        if (rig.velocity.y > 11)
            rig.velocity = new Vector2(rig.velocity.x, 11);

        Anim.SetBool("jumping", !jump);

    }

    void Attack()
    {
        if (jump)
        {
            if (Input.GetButtonDown("Attack"))
            {
                swingPlayer.GetComponent<AudioSource>().PlayOneShot(swings[UnityEngine.Random.Range(0, swings.Length - 1)]);
                Anim.SetTrigger("attack");
                attack = true;
            }
        }
        else
            attack = false;
       
      
    }

    void Guard()
    {
        if(!attack && Input.GetAxisRaw("Horizontal") == 0 && Input.GetButton("Guard"))
            Anim.SetBool("duck", true);
        else
            Anim.SetBool("duck", false);


        guard = Anim.GetBool("duck");

    }


    void ThrowAxe()
    {
        if(axeTimer > axeCooldown)
        {
            GameObject thorwnObj = ThrowObject(axe);

            thorwnObj.GetComponent<Axe>().dir = dir;

            axeTimer = 0;
        }
        
    }

    void UpdateHealthbar()
    {

        if (healthbar[0] == null)
            return;

        int h = health / 10;

       

        for(int i = 0; i < healthbar.Length; i++)
        {
            healthbar[i].enabled = true;

            if (i+1 > h)
            {
                healthbar[i].enabled = false;
            }
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        rayCount = Mathf.Clamp(rayCount, 2, int.MaxValue);

        raySpacing = bounds.size.x / (rayCount - 1);
    }

    public override IEnumerator TakeDamage()
    {
        int chance = 0;
        if (guard)
        {
            chance = UnityEngine.Random.Range(1, 10);

        }

        if(!IsDead)
        {
            if(chance < 6)
            {
                health -= 10;
            }

            PlayerInformation.health = health;

            blood.Play();

            UpdateHealthbar();

            if (!IsDead)
            {
                Anim.SetTrigger("damage");
            }
            else
            {
                Anim.SetTrigger("dead");
            }
        }
        
        yield return null;
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public void kill()
    {
        health = -10;
    }

    public void heal()
    {
        health = 50;
        UpdateHealthbar();
    }
}
