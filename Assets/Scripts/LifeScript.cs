using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    Ui ui;

    public bool unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UI Image").GetComponent<Ui>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (unlocked)
            {
                ui.Lives++;
                ui.ReplaceActiveCharacter();
                Destroy(gameObject);
            }
            
        }
    }
}
