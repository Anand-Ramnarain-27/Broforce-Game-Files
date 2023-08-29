using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTerrain : MonoBehaviour
{
    public Tilemap destructableTilemap;

    public float terrainHealth = 5;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the gameobject collided with anither with the tag ammo
        if (collision.gameObject.CompareTag("bullet"))
        {
            terrainHealth -= 1;
            Vector3 hitPosition = Vector3.zero;
            Vector3 reaction = Vector3.zero;

            //Runs loop to check each point to the object collides with to get its position.
            foreach (ContactPoint2D hit in collision.contacts)
            {
                //Give the position of the tile hit, uses the float and nornal to get the surface ponit of the tile
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                reaction.x = hit.point.x + 0.01f * hit.normal.x;
                reaction.y = hit.point.y + 1f * hit.normal.y;

                if(terrainHealth == 0)
                {
                    destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
                    destructableTilemap.SetTile(destructableTilemap.WorldToCell(reaction), null);
                    terrainHealth = 5;
                }
                
            }
        }
    }
}
