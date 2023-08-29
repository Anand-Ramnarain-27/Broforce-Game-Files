using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Rockets : MonoBehaviour
{
    public float speed;
    public GameObject Boom;
    public GameObject Lines;

    Collider2D[] targetinRad;
    public Tilemap tilemap;
    public CircleCollider2D cc;

    public RocketDetection rock;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        tilemap = GameObject.Find("Main").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        targetinRad = Physics2D.OverlapCircleAll(transform.position, cc.radius);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }



    private void OnCollisionEnter2D(Collision2D coll)
    {


        if (coll.gameObject.tag == "Terrain") 
        {
            
            Instantiate(Boom, transform.position, Boom.transform.rotation);
            
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

                Vector3 u = item.gameObject.transform.position;
                u.y = item.gameObject.transform.position.y + 2f;
                u.x = item.gameObject.transform.position.x - 1f;
                tilemap.SetTile(tilemap.WorldToCell(u), null);

                Vector3 i = item.gameObject.transform.position;
                i.y = item.gameObject.transform.position.y + 2f;
                i.x = item.gameObject.transform.position.x + 1f;
                tilemap.SetTile(tilemap.WorldToCell(i), null);

                Vector3 o = item.gameObject.transform.position;
                o.y = item.gameObject.transform.position.y + 1;
                o.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(o), null);

                Vector3 p = item.gameObject.transform.position;
                p.y = item.gameObject.transform.position.y + 2;
                p.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(p), null);

                Vector3 two = item.gameObject.transform.position;
                two.y = item.gameObject.transform.position.y;
                two.x = item.gameObject.transform.position.x + 2f;
                tilemap.SetTile(tilemap.WorldToCell(two), null);

                rock.Bombs -= 1;
                Debug.Log(item.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
