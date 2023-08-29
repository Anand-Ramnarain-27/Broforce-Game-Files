using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int Damage;
    public GameObject Player;
    public Vector2 Direction;
    public GameObject Hit;

    private void Start()
    {
       
        transform.SetParent(null, true);
        Player = GameObject.Find("Player");

        if (Player.transform.localScale.x == 1)
        {
            Debug.Log("Right");
            Direction = Vector2.right;
        }
        if (Player.transform.localScale.x == -1)
        {
            Debug.Log("Left");
            Direction = Vector2.left;
        }

    }

    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);

    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Terrain")
        {

            Break();
        }

        if (coll.gameObject.tag == "Enemy")
        {
            Unit unit = coll.gameObject.GetComponent<Unit>();
            unit.TakeDamage(5);
            Destroy(gameObject);
        }
    }

    public void Break()
    {
        Instantiate(Hit, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
