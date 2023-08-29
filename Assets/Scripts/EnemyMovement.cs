using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 2f;
    public float attackRange = 2f;
    public float attackDelay = 1f;
    public float aimOffset = 0.5f; // Offset value to adjust the aiming position
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    public GameObject awareSign;

    private bool isAttacking = false;
    public bool close = false;
    public bool closer = false;
    private bool initialDelayPassed = false;

    [SerializeField]
    private float initialDelay; // Change this value to set the initial delay time

    private float attackTimer = 0f;

    public Animator anim;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>().transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < 20)
        {
            awareSign.SetActive(true);
        } else
        {
            awareSign.SetActive(false);
        }


       

        if (player.position.x < transform.position.x)
        {
            // If the player is to the left of the object, flip it to face left.
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else
        {
            // If the player is to the right of the object, flip it to face right.
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }

        if (close)
        {
            anim.SetBool("Aware", true);
            anim.SetBool("Neutral", false);

            if (distanceToPlayer > attackRange)
            {
                // Move towards the player
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * movementSpeed * Time.deltaTime);
                anim.SetBool("Aware", false);
                anim.SetBool("Walk", true);

                if (direction.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1); // No scaling on x-axis for facing right
                }
                else if (direction.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1); // Flip the sprite on x-axis for facing left
                }
            }
            else 
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Aware", true);
            }

            if (!initialDelayPassed)
            {
                // Increment the timer until the initial delay has passed
                initialDelay -= Time.deltaTime;

                // Check if the initial delay has passed
                if (initialDelay <= 0f)
                {
                    initialDelayPassed = true;
                }
            }
            else
            {
                if (!isAttacking && distanceToPlayer <= attackRange)
                {
                    // Within attack range, initiate attack
                    Attack();
                }
                else if (isAttacking)
                {
                    // Continue attack for a set duration
                    attackTimer += Time.deltaTime;
                    if (attackTimer >= attackDelay)
                    {
                        isAttacking = false;
                        attackTimer = 0f;
                    }
                }
            }
        }

        if (distanceToPlayer <= 15 && closer)
        {
            close = true;
        } else
        {
            close = false;
            anim.SetBool("Neutral", true);
            anim.SetBool("Aware", false);
            anim.SetBool("Walk", false);
        }
        
    }

    private void Attack()
    {
        // Perform attack action
        isAttacking = true;
        attackTimer = 0f;

        Vector2 targetPosition = player.position + new Vector3(0f, aimOffset, 0f); // Apply offset to target position

        Vector2 direction = (Vector2)targetPosition - (Vector2)projectileSpawnPoint.position;
        direction.Normalize();

        // Instantiate the bullet prefab at the fire point position
        GameObject bullet = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Set the bullet's direction
        EnemyBullet bullett = bullet.GetComponent<EnemyBullet>();

        if (bullett != null)
        {
            bullett.SetDirection(direction);
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have BulletMovement component.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closer = false;
        }
    }

}
