using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BrodellGrenade : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public Vector2 Direction;
    public GameObject Player;

    public Movement move;

    public Vector2 Spawn;
    public float X;
    public float Y;
    public GameObject Boom;


    private void Start()
    {
        Direction = transform.right;
        Direction = Vector2.left;
        Player = GameObject.Find("Player");
        move = GameObject.Find("Player").GetComponent<Movement>();
        transform.SetParent(null, true);
        StartCoroutine(Boom1());



        Destroy(gameObject, 5);

        if (move.Right == false)
        {
            var direction = (Vector2.left*2) + Vector2.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
            transform.Translate(LaunchOffset);
            Debug.Log("Left");
        }
        if (move.Right == true)
        {
            var direction = (Vector2.right*2) + Vector2.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
            transform.Translate(LaunchOffset);
            Debug.Log("Right");
        }
    }

    public void Update()
    {
        Spawn = new Vector2(X, Y);
        X = transform.position.x;
        Y = transform.position.y + 0.5f;
    }

    public IEnumerator Boom1()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(Boom, Spawn, transform.rotation);
        Destroy(gameObject);
        Debug.Log("Red");
        
    }
}
