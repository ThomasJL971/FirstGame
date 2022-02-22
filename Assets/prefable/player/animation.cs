using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class animation : MonoBehaviour {


    //public float attackCooldown;
    //private bool isAttacking;
    //private float currentCooldown;
    private int Jump = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;
    private Animator Anim;
    private float attackTime;
    public float attackRepeaTime = 1;
    PlayerInventory playerInv;

    private bool moving = false;
    public FixedButton Button;

    public float attackRange;
    public GameObject rayHit;

    // Use this for initialization
    void Start () {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        attackTime = Time.time;
        rayHit = GameObject.Find("RayHit");
        playerInv = gameObject.GetComponent<PlayerInventory>();
    }
	




	// Update is called once per frame
	void Update () {


        if (CrossPlatformInputManager.GetButtonDown("Jump") && Player.isGrounded)
        {
            DirectionDeplacement.y = Jump;

        }
        //Animation
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0 || CrossPlatformInputManager.GetAxis("Vertical") < 0)
        {
            moving = true;
        }
        if (moving == true)
        {
            Anim.SetBool("Walk", true);
        }

        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Horizontal") < 0)
        {
            moving = true;
        }
        if (moving == true)
        {
            Anim.SetBool("Walk", true);
        }

        if (CrossPlatformInputManager.GetAxis("Vertical") == 0 || CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {
            moving = false;
        }
        if (moving == false)
        {
            Anim.SetBool("Walk", false);
            
        }

        
        
    }
    public void Attack()
    {
        Anim.SetTrigger("Combo");
        attackTime = Time.time + attackRepeaTime;
        RaycastHit hit;

        if(Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);

            if(hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<enemyAi>().ApplyDammage(playerInv.currentDamage);
            }
        }
    }

    public void Attack2()
    {
        Anim.SetTrigger("attack");
        attackTime = Time.time + attackRepeaTime;
        RaycastHit hit;

        if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
        {
            Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<enemyAi>().ApplyDammage(playerInv.currentDamage);
            }
        }
    }
}
