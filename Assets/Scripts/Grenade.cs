using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grenade : MonoBehaviour
{
    public float speed = 4;
    public Vector3 LaunchOffset;
    
    public bool Thrown;
   
    public GameObject Player;
    public GameObject Boom;
    public GameObject Black;
    public GameObject Bomb;

    public Vector2 Spawn;
    public float X;
    public float Y;

    public GameObject Red;
    public Sprite Current;

    Collider2D[] targetinRad;
    public Tilemap tilemap;
    public CircleCollider2D cc;

    bool isexploding = false;

    //// Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        tilemap = GameObject.Find("Main").GetComponent<Tilemap>();
        Bomb = gameObject;
        Current = GetComponent<SpriteRenderer>().sprite;
        //    Move = true;
        Player = GameObject.Find("Player");
        //    StartCoroutine("Stop");
        transform.SetParent(null, true);

       

        if (Thrown)
        {
            
            if (Player.transform.localScale.x == 1)
            {
                var direction = transform.right*1.5f + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            }
            if (Player.transform.localScale.x == -1)
            {
                var direction = -transform.right*1.5f + Vector3.up;
                GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
            }

            

        }
        transform.Translate(LaunchOffset);

        StartCoroutine(Boom1());
    }

    //// Update is called once per frame
    void Update()
    {
        targetinRad = Physics2D.OverlapCircleAll(transform.position, cc.radius);
        Spawn = new Vector2(X, Y);
        X = transform.position.x;
        Y = transform.position.y + 0.4f;

       

    }

    

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain") && isexploding)
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
                t.y = item.gameObject.transform.position.y ;
                t.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(t), null);

                Vector3 y = item.gameObject.transform.position;
                y.y = item.gameObject.transform.position.y;
                y.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(y), null);

                Vector3 u = item.gameObject.transform.position;
                u.y = item.gameObject.transform.position.y + 2f;
                u.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(u), null);

                Vector3 i = item.gameObject.transform.position;
                i.y = item.gameObject.transform.position.y + 2f;
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

                Vector3 two = item.gameObject.transform.position;
                two.y = item.gameObject.transform.position.y ;
                two.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(two), null);

                Debug.Log(item.gameObject.name);
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator Boom1()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Red.GetComponent<SpriteRenderer>().color;
        Debug.Log("Red");
        StartCoroutine(Boom2());
    }

    public IEnumerator Boom2()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Black.GetComponent<SpriteRenderer>().color;
        
        StartCoroutine(Boom3());
    }

    public IEnumerator Boom3()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Red.GetComponent<SpriteRenderer>().color;
       
        StartCoroutine(Boom4());
    }
    public IEnumerator Boom4()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Black.GetComponent<SpriteRenderer>().color;
        
        StartCoroutine(Boom5());
    }

    public IEnumerator Boom5()
    {
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Red.GetComponent<SpriteRenderer>().color;

        StartCoroutine(Boom6());
    }

    public IEnumerator Boom6()
    {
        yield return new WaitForSeconds(0.25f);
        
        Instantiate(Boom, Spawn, transform.rotation);
        isexploding = true;
        //Destroy(gameObject);
        Debug.Log("Red");
    }
}
