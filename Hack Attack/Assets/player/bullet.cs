using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bullet : MonoBehaviour
{
    public int damage = 1; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        chaser enemy = collision.GetComponent<chaser>();
        TilemapCollider2D wall = collision.GetComponent<TilemapCollider2D>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(wall)
        { Destroy(gameObject); }
    }
}
