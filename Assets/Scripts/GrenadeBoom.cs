using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBoom : MonoBehaviour
{
    public GameObject Rockets;
    public Vector2 Position;

    // Start is called before the first frame update
    void Start()
    {
        Position = new Vector2(transform.position.x, transform.position.y-0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
       
        Destroy(gameObject);
    }

    public void Display()
    {
        if (GameObject.Find("Brodell Walker") != null)
        {
            Instantiate(Rockets, Position, transform.rotation);

        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Unit unit = collision.GetComponent<Unit>();
            unit.TakeDamage(5);
        }

        if (collision.CompareTag("Bomb1"))
        {
            Bomb_1 bomb1 = collision.GetComponent<Bomb_1>();
            bomb1.fire.SetActive(true);
            bomb1.countdown = bomb1.explodeTime;
        }

    }
}
