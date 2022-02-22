using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public Current Health playerHealth;       // Reference to the player's heatlh.
    //Cible de l'ennemi
    public Transform Target;

    //Distance entre le joueur et l'ennemi
    private float Distance;

    //Distance de poursuite
    public float chaseRange = 10;

    //portée des attaques
    public float attackRange = 2.2f;

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {

        //On cherche le joueur en permanance
        Target = GameObject.Find("player").transform;

        //on calcule la distance entre le joueur et l'ennemi, en fonction de cette distance on effectue diverses actions
        Distance = Vector3.Distance(Target.position, transform.position);

        // If the player has no health left...
        if (Distance < chaseRange && Distance > attackRange)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        
    }
}
