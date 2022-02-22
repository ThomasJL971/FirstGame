
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class playerController : MonoBehaviour {

    

    private const string Name = "vertical";
    public int Speed = 5;
    //private Vector3 DirectionDeplacement = Vector3.zero;
    //private CharacterController Player;
    //private int Jump = 5;
    public int gravite = 20;

    protected Rigidbody Rigidbody;

    //private bool moving = false;


    //public FixedJoystick LeftJoystick;
    //public FixedButton Button;
    protected float CameraAngleY;

    


    //public float x = 1.5f;

    public float turnSpeed = 20f;


    //animation

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

    //camera

    public FixedTouchField Touchfield;

    //private Vector3 DirectionDeplacement = Vector3.zero;
    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    public bool isDead = false;
    public bool arret = false;


    // Use this for initializatio
    void Start () {
      
        Player = GetComponent<CharacterController>();
        Rigidbody = GetComponent<Rigidbody>();

        //animation

        //Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        attackTime = Time.time;
        rayHit = GameObject.Find("RayHit");
        playerInv = gameObject.GetComponent<PlayerInventory>();


    }

    // Update is called once per frame
    void Update () {


        //Gravité
        if (!Player.isGrounded)
        {
            DirectionDeplacement.y -= gravite * Time.deltaTime;
        }

        if (!isDead)
        {
             //control
            DirectionDeplacement.z = CrossPlatformInputManager.GetAxisRaw("Vertical");
            DirectionDeplacement.x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            //Vector3 mouvment = new Vector3(DirectionDeplacement.x, 0, DirectionDeplacement.z);


            Player.Move(DirectionDeplacement * Time.deltaTime * Speed);

            float x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            float y = CrossPlatformInputManager.GetAxisRaw("Vertical");
            if (x != 0f || y != 0f)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            Player.Move(DirectionDeplacement * Time.deltaTime * Speed);


            CameraAngle += Touchfield.TouchDist.x * CameraAngleSpeed;

            Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 3, 4);//3 3 6
            Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
           
            //animation

            //saut
            if (CrossPlatformInputManager.GetButtonDown("Jump") && Player.isGrounded)
            {
                //DirectionDeplacement.y = Jump;

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
    }

    public void Roulad()
    {
        Anim.SetTrigger("Roulade");
    }

    public void Attack()
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
    //fin animation


}
