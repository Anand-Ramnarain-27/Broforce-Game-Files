using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil_walk : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private Transform devil;

    [SerializeField] private float speed;
    private Vector3 initScale;

    private bool movingLeft;

    public float health = 20;

    public GameObject win;

    private void Awake()
    {
        initScale = devil.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (devil.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }else
            {
                if(devil.position.x<= rightEdge.position.x)
                MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direc)
    {
        //Move in that direction
        devil.position = new Vector3(devil.position.x + Time.deltaTime * _direc * speed,
            devil.position.y,devil.position.z);

        devil.localScale = new Vector3(Mathf.Abs(initScale.x) * _direc, initScale.y, initScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            if(health > 0)
            {
                health = health - 5;
            }
            else if(health <= 0)
            {
                win.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
