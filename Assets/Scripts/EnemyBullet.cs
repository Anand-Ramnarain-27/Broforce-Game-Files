using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;
    private Rigidbody2D rb;

    public GameObject player;

    public GameObject impactEffectPrefab;

    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Move the laser using the Rigidbody2D component
        rb.velocity = direction * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        // Set the direction of the laser
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.CompareTag("Player"))
        {
            Unit playerUnit = collision.GetComponent<Unit>();

            playerUnit.TakeDamage(5);
            Debug.Log("Player hit!");
        }

        if (!collision.CompareTag("Enemy") && !collision.CompareTag("MainCamera"))
            Destroy(gameObject);



        // Get the closest point on the collider to the current transform position
        Vector2 collisionPoint = collision.ClosestPoint(transform.position);

        // Spawn the impact effect at the collision point
        Instantiate(impactEffectPrefab, collisionPoint, Quaternion.identity);
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        // Calculate the rotation angle based on the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the bullet
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

