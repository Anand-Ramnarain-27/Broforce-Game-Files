using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb_1 : MonoBehaviour
{
    public float explodeTime = 3;
    public float explosionRange = 10f;
    public float countdown = 0;

    bool isExploding = false;

    public GameObject player;
    public GameObject fire;
    public GameObject explode;
    public GameObject flash;

    private Rigidbody2D rb;

    public CircleCollider2D cc;
    public Tilemap tilemap;
    Collider2D[] targetinRad;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        tilemap = GameObject.Find("Main").GetComponent<Tilemap>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetinRad = Physics2D.OverlapCircleAll(transform.position, cc.radius);
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                // Perform the explosion-related logic here
                isExploding = true;
                fire.SetActive(false);
                flash.SetActive(false);
                explode.SetActive(true);
                //StartCoroutine(DestroyBomb());
            }
        }

        if (countdown <= 0 && IsFalling())
        {
            Debug.Log("IS FALLING!");
            StartCoroutine(Fire());
        }

        // Check if the bomb has landed and is exploding
        if (countdown <= 0 && isExploding)
        {
            // Apply damage to the player if they are in the explosion range
            if (Vector2.Distance(transform.position, player.transform.position) <= explosionRange)
            {
                Unit playerUnit = player.GetComponent<Unit>();
                if (playerUnit != null)
                {
                    // Use playerUnit.TakeDamage() method to apply damage to the player
                    playerUnit.TakeDamage(10); // Adjust the damage value as needed
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            fire.SetActive(true);
            countdown = explodeTime;
       }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Do nothing if countdown is still ongoing
        if (countdown > 0)
            return;

        if (!isExploding)
            return;

        // Damage the terrain or other objects in the trigger space
        if (collision.CompareTag("Terrain"))
        {
            foreach (var item in targetinRad)
            {
                Vector3 two = item.gameObject.transform.position;
                two.y = item.gameObject.transform.position.y - 2f;
                two.x = item.gameObject.transform.position.x;
                tilemap.SetTile(tilemap.WorldToCell(two), null);

                Vector3 three = item.gameObject.transform.position;
                three.y = item.gameObject.transform.position.y - 1f;
                three.x = item.gameObject.transform.position.x;
                tilemap.SetTile(tilemap.WorldToCell(three), null);

                Vector3 a = item.gameObject.transform.position;
                a.y = item.gameObject.transform.position.y + 2f;
                a.x = item.gameObject.transform.position.x;
                tilemap.SetTile(tilemap.WorldToCell(a), null);

                Vector3 s = item.gameObject.transform.position;
                s.y = item.gameObject.transform.position.y + 1f;
                s.x = item.gameObject.transform.position.x;
                tilemap.SetTile(tilemap.WorldToCell(s), null);

                Vector3 four = item.gameObject.transform.position;
                four.y = item.gameObject.transform.position.y - 1;
                four.x = item.gameObject.transform.position.x - 1;
                tilemap.SetTile(tilemap.WorldToCell(four), null);

                Vector3 five = item.gameObject.transform.position;
                five.y = item.gameObject.transform.position.y - 1;
                five.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(five), null);

                Vector3 q = item.gameObject.transform.position;
                q.y = item.gameObject.transform.position.y;
                q.x = item.gameObject.transform.position.x - 1;
                tilemap.SetTile(tilemap.WorldToCell(q), null);

                Vector3 w = item.gameObject.transform.position;
                w.y = item.gameObject.transform.position.y;
                w.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(w), null);

                Vector3 e = item.gameObject.transform.position;
                e.y = item.gameObject.transform.position.y + 1f;
                e.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(e), null);

                Vector3 r = item.gameObject.transform.position;
                r.y = item.gameObject.transform.position.y + 1f;
                r.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(r), null);

                Vector3 u = item.gameObject.transform.position;
                u.y = item.gameObject.transform.position.y + 2f;
                u.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(u), null);

                Vector3 i = item.gameObject.transform.position;
                i.y = item.gameObject.transform.position.y + 2f;
                i.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(i), null);

                Vector3 z = item.gameObject.transform.position;
                z.y = item.gameObject.transform.position.y;
                z.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(z), null);

                Vector3 o = item.gameObject.transform.position;
                o.y = item.gameObject.transform.position.y + 1;
                o.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(o), null);

                Vector3 p = item.gameObject.transform.position;
                p.y = item.gameObject.transform.position.y + 2;
                p.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(p), null);

                Vector3 d = item.gameObject.transform.position;
                d.y = item.gameObject.transform.position.y;
                d.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(d), null);


                Debug.Log(item.transform.position);
                Debug.Log(item.gameObject.name); ;

                Destroy(gameObject);
            }
        }
    }


    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(5); // Adjust the time delay as needed

       // Destroy(gameObject);
    }

    private bool IsFalling()
    {
        // Check the bomb's vertical velocity to determine if it's falling (negative or close to 0)
        return rb.velocity.y < -0.1f;
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2);

        // Start the explosion process when the bomb lands on the ground (its vertical velocity is less than or equal to 0)
        fire.SetActive(true);
        countdown = explodeTime;
    }
}