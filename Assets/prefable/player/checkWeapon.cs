using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWeapon : MonoBehaviour {

    //id de l'arme actuelle
    private int weaponID;

    //Liste de nos armes se trouvant dans la main du pesonnage
    public List<GameObject> weaponList = new List<GameObject>();


	// Update is called once per frame
	void Update () {
	 /*if(transform.childCount > 0)
        {
            weaponID = gameObject.GetComponentsInChildren<ItemOnObject>().Item.itemID;
        }
        else
        {
            weaponID = 0;
            if (weaponID == 1 && transform.childCount > 0)
            {
                for (int i = 0; i < weaponList.Count; i++)
                {
                    weaponList[i].SetActive(false);
                }
            }
        }


    if(weaponID == 1 && transform.childCount > 0)
        {
            for(int i=0; i< weaponList.Count; i++)
            {
                if (i == 0)
                {
                    weaponList[i].SetActive(true);
                }

            }
        }*/
	}
}
