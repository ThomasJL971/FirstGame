using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{

    public GameObject Panelmenu;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            Panelmenu.SetActive(true);
            UnityEngine.Cursor.visible = true;
            //Application.Quit();

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panelmenu.SetActive(false);
            UnityEngine.Cursor.visible = false;
            //Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Panel.SetActive(false);
            //Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Panel.SetActive(true);
            //Application.Quit();

        }

    }
}
