using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb_2 : MonoBehaviour
{
    public float explodeTime = 3;
    public float explosionRange = 10f;

    bool isExploding = false;

    public GameObject player;
    public GameObject explode;
    public GameObject flash;

    private Rigidbody2D rb;

    Collider2D[] targetinRad;
    public Tilemap tilemap;
    public CircleCollider2D cc;

    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        tilemap = GameObject.Find("Main").GetComponent<Tilemap>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetinRad = Physics2D.OverlapCircleAll(transform.position, cc.radius);

        if (IsFalling())
        {
            StartCoroutine(Fire());
        }

        // Check if the bomb has landed and is exploding
        if (isExploding)
        {
            // Apply damage to the player if they are in the explosion range
            if (Vector2.Distance(transform.position, player.transform.position) > explosionRange)
            {
                return;
            }
            Unit playerUnit = player.GetComponent<Unit>();
            if (playerUnit != null)
            {
                // Use playerUnit.TakeDamage() method to apply damage to the player
                playerUnit.TakeDamage(10); // Adjust the damage value as needed
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("bullet"))
        {
         isExploding = true;
         flash.SetActive(false);
         explode.SetActive(true);
         StartCoroutine(DestroyBomb());
         }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!isExploding)
            return;

        // Damage the terrain or other objects in the trigger space
        if (collision.CompareTag("Terrain"))
        {
            //Stores of objects in "items" within the raduis of the object "targetinRad"
            foreach (var item in targetinRad)
            {
                Vector3 one = item.gameObject.transform.position;
                one.y = item.gameObject.transform.position.y;
                one.x = item.gameObject.transform.position.x;
                tilemap.SetTile(tilemap.WorldToCell(one), null);

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

                Vector3 t = item.gameObject.transform.position;
                t.y = item.gameObject.transform.position.y;
                t.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(t), null);

                Vector3 y = item.gameObject.transform.position;
                y.y = item.gameObject.transform.position.y;
                y.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(y), null);

                Vector3 i = item.gameObject.transform.position;
                i.y = item.gameObject.transform.position.y;
                i.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(i), null);

                Vector3 o = item.gameObject.transform.position;
                o.y = item.gameObject.transform.position.y+1;
                o.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(o), null);

                Vector3 p = item.gameObject.transform.position;
                p.y = item.gameObject.transform.position.y + 2;
                p.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(p), null);

                Vector3 d = item.gameObject.transform.position;
                d.y = item.gameObject.transform.position.y ;
                d.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(d), null);

                Debug.Log(item.gameObject.name);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            Unit enemyUnit = collision.gameObject.GetComponent<Unit>();
            enemyUnit.TakeDamage(5);
        }
    }


    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(2); // Adjust the time delay as needed

        Destroy(gameObject);
    }

    private bool IsFalling()
    {
        // Check the bomb's vertical velocity to determine if it's falling (negative or close to 0)
        return rb.velocity.y < -0.1f;
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1);

        isExploding = true;
        flash.SetActive(false);
        explode.SetActive(true);
        StartCoroutine(DestroyBomb());
    }
}
