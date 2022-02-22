using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{

    public float spellDammage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerInventory>().ApplyDamage(spellDammage);
            
        }
        
            //Destroy(gameObject);
        
    }
}
