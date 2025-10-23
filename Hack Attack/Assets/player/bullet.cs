using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 1; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        chaser enemy = collision.GetComponent<chaser>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
