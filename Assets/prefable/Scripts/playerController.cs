
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour {

    
    
    
    
    //public int gravite = 20;

    protected Rigidbody Rigidbody;

    //public FixedJoystick LeftJoystick;
    //public FixedButton Button;
    protected float CameraAngleY;


    public float turnSpeed = 20f;


    //animation

    //public float attackCooldown;
    //private bool isAttacking;
    //private float currentCooldown;
    private int Jump = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController player;
    private Animator Anim;
    private float attackTime;
    public float attackRepeaTime = 1;
    PlayerInventory playerInv;

    private bool moving = false;
    

    public float attackRange;
    public GameObject rayHit;

    //camera

    //private Vector3 DirectionDeplacement = Vector3.zero;
    //protected float CameraAngle;
    //protected float CameraAngleSpeed = 0.2f;

    public bool isDead = false;
    public bool arret = false;
    

    //public Transform target;

    //Input PC
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public float walkSpeed;
    public float runSpeed;

    public GameObject cam;
    CapsuleCollider playerCollider;
    // Use this for initialization
    void Start () {
      
        player = GetComponent<CharacterController>();
        Rigidbody = GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        //animation

        
        Anim = GetComponent<Animator>();
        attackTime = Time.time;
        rayHit = GameObject.Find("RayHit");
        playerInv = gameObject.GetComponent<PlayerInventory>();

        //sourie invisible
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {

        


        //Gravité
        //if (!Player.isGrounded)
        //{
          //  DirectionDeplacement.y -= gravite * Time.deltaTime;
        //}
        
        if (!isDead)
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Input.GetKey(inputFront))
                {
                    transform.Translate(0, 0, walkSpeed * Time.deltaTime);
                    Anim.SetBool("Walk", true);

                }
                else
                {
                    Anim.SetBool("Walk", false);
                }

                if (Input.GetKey(inputBack))
                {
                    transform.Translate(0, 0, -(walkSpeed / 2) * Time.deltaTime);
                    Anim.SetBool("back", true);

                }
                else
                {
                    Anim.SetBool("back", false);
                }

                if (Input.GetKey(inputLeft))
                {
                    transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);


                }

                if (Input.GetKey(inputRight))
                {
                    transform.Rotate(0, turnSpeed * Time.deltaTime, 0);


                }

                if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(0, 0, runSpeed * Time.deltaTime);
                    Anim.SetBool("run", true);

                }
                else
                {
                    Anim.SetBool("run", false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }

            

        }
    }

    public void Roulad()
    {
        if (!isDead)
        {
            Anim.SetTrigger("Roulade");
        }
    }

    public void Attack2()
    {
        if (!isDead)
        {
            arret = true;
            Anim.SetTrigger("Combo");
            attackTime = Time.time + attackRepeaTime;
            RaycastHit hit;

            if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);

                if (hit.transform.tag == "Enemy")
                {
                    //hit.transform.GetComponent<enemyAi>().ApplyDammage(playerInv.currentDamage);
                }
            }
        }
    }

    public void Attack()
    {
        if (!isDead)
        {
            Anim.SetTrigger("attack");
            attackTime = Time.time + attackRepeaTime;
            RaycastHit hit;

            if (Physics.Raycast(rayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, attackRange))
            {
                Debug.DrawLine(rayHit.transform.position, hit.point, Color.red);

                if (hit.transform.tag == "Enemy")
                {
                    //hit.transform.GetComponent<enemyAi>().ApplyDammage(playerInv.currentDamage);
                }
            }
        }
    }
    //fin animation


}
