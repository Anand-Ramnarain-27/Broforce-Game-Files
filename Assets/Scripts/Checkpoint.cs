using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public GameObject player;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("appear");
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
