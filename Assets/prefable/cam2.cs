using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // objet a suivre
    public float speed; // vitesse à la laquelle la camera suit le joueur 
    public Vector3 decalage; // si l'on veut situer la camera à un endroit precis par rapport au personnage
	float xPos;// index qui sert à savoir si on regarde à gauche ou à droite

	// Use this for initialization
	void Start () {
        if (target == null)// si la cible visé par la camera est nul on lui assigne le player.
        {
            target = GameObject.Find("Player").transform;
        }
		xPos = decalage.x;//l'indice de position est egale au décalage que l'on a attribuer à la camera.
	}
	
	// Update is called once per frame
	void Update () {
        // la camera ce deplace en fonction du joueur tout en gardant son décalage.
		transform.position = Vector3.Lerp(transform.position, target.position + decalage, speed * Time.deltaTime);

		decalage.x = xPos;// le decalage en x est egale à l'indice de position en x
		/*  je change la valeur de l'indice en fonction de la direction prise par le joueur
			A gauche valeur negative
			A droite valeur positive

			ce qui permet grace au décalage d'avoir un plus grand apercu de ce qui ce passe plus loin dans le niveau.
		 */
		if (Input.GetAxisRaw ("Horizontal") < 0)
		{
			if ( xPos < 0 ){
				xPos = decalage.x;
			}else
			{
				xPos = decalage.x*-1;
			}
		}

		if (Input.GetAxisRaw ("Horizontal") > 0)
		{
			if ( xPos < 0 ){
				xPos = decalage.x*-1;
			}else
			{
				xPos = decalage.x;
			}
		}
	}
}

