using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Movement move;
    public GameObject gun;
    public GameObject gun2;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Weapon");
        gun2 = GameObject.Find("Weapon2");
        move = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Terrain")
        {
            move.onWall = true;
            
        }


    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Terrain")
        {
            move.onWall = false;

            if (gun == null)
            {
                gun = GameObject.Find("Weapon");
                gun.SetActive(true);
            } else
            {
                gun.SetActive(true);
            }
            
            gun2.SetActive(false);
        }


    }
}
