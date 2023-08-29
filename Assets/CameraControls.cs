using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject Cam;
    public GameObject Player;
    public Vector3 CamPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D coll)
    {
       
        if (coll.gameObject.name == "Player")
        {
            CamPosition = new Vector3(Player.transform.position.x, Player.transform.position.y+0.2f, Cam.transform.position.z);
            Cam.transform.position = CamPosition;
        }
       
    }
}
