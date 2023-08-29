using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RambroSHoot : MonoBehaviour
{
    public GameObject BulletSpawn;
    public GameObject GrenadeSpawn;
    public GameObject gun;
    public GameObject gun2;
    public GameObject Player;
    public GameObject Bullet;
    public GameObject Grenade;

    public Grenade Gren;
    public Ui ui;
    public Movement move;

    public bool CanShoot;
    public bool CanThrow;

    public Vector3 from = new Vector3(0f, 0f, 5f);
    public Vector3 to = new Vector3(0f, 0f, -5f);

    public float speed = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        ui = GameObject.Find("UI Image").GetComponent<Ui>();
        move = GameObject.Find("Player").GetComponent<Movement>();
        gun = GameObject.Find("Weapon");
        gun2 = GameObject.Find("Weapon2");
        //shooting
        CanShoot = true;
        //CanThrow = true;
        //


    }

    // Update is called once per frame
    void Update()
    {
        //shooting
        if(Input.GetKey(KeyCode.T) && CanShoot == true)
        {
            CanShoot = false;
            Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation, transform);
            StartCoroutine(ShootAgain());
        }
        //

        if (Input.GetKey(KeyCode.Y) && CanThrow == true && ui.CurrentPowers > 0)
        {
            ui.CurrentPowers -= 1;
            move.canMove = false;
            GetComponent<Animator>().SetBool("Throw", true);
            gun.SetActive(false);
            gun2.SetActive(false);
            CanThrow = false;
            StartCoroutine(Throw());

        }

        float t = (Mathf.Sin(Time.time * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        BulletSpawn.transform.eulerAngles = Vector3.Lerp(from, to, t);
    }
    public IEnumerator ShootAgain()
    {
        yield return new WaitForSeconds(0.1f);
        CanShoot = true;
    }
    public IEnumerator Throw()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(Gren, GrenadeSpawn.transform.position, transform.rotation, transform);
        StartCoroutine(ThrowAgain());

    }
    public IEnumerator ThrowAgain()
    {
        yield return new WaitForSeconds(0.5f);
        CanThrow = true;
        
    }
    public void Stop()
    {
        GetComponent<Animator>().SetBool("Throw", false);
        move.canMove = true;
        gun.SetActive(true);
        gun2.SetActive(false);
    }


}
