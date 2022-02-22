using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
    //Cible de l'ennemi
    public Transform Target;

    //Distance entre le joueur et l'ennemi
    private float Distance;

    //Distance de poursuite
    public float chaseRange = 10;

    //portée des attaques
    public float attackRange = 2.2f;

    //cooldown des attaques
    public float attackRepeaTime = 1;
    private float attackTime;

    //Montant des dégats infligés
    public float TheDammage;

    //agent de navigation
    public UnityEngine.AI.NavMeshAgent agent;

    //animation
    private Animation animations;

    private Animator Anim;

    // vie
    public float enemyHealth;

    private bool isDead = false;

    // Use this for initialization
    void Start () {

        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!isDead)
        {

            //On cherche le joueur en permanance
            Target = GameObject.Find("player").transform;

            //on calcule la distance entre le joueur et l'ennemi, en fonction de cette distance on effectue diverses actions
            Distance = Vector3.Distance(Target.position, transform.position);

            // Quand il est loin
            if (Distance > chaseRange)
            {
                idle();
            }

            //quand il est proche mais pas assez pour attaquer
            if (Distance < chaseRange && Distance > attackRange)
            {
                chase();
            }

            //quand il est proche pour attaquer
            if (Distance < attackRange)
            {
                attack();
            }
        }
	}

    void chase()
    {
        Anim.SetBool("Walk", true);
        agent.destination = Target.position;
    }

    void attack()
    {
        // empeche l'ennemi de traverser le joueur
        agent.destination = transform.position;

        if(Time.time > attackTime)
        {
            Anim.SetBool("attack", true);
            Target.GetComponent<PlayerInventory>().ApplyDamage(TheDammage);
            Debug.Log("L'ennemi a envoyé " + TheDammage);
            attackTime = Time.time + attackRepeaTime;
        }
    }

    //idle
    void idle()
    {
        Anim.SetBool("idle", true);
    }

    public void ApplyDammage(float TheDamage)
    {
        if (!isDead)
        {
            enemyHealth = enemyHealth - TheDamage;
            print(gameObject.name + "a subit " + TheDamage);

            if(enemyHealth <= 0)
            {
                Dead();
            }
        }
    }
     public void Dead()
    {
        isDead = true;
        Anim.SetTrigger("dead");
        Destroy(transform.gameObject, 10);
    }
}
