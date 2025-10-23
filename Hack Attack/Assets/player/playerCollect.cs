using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        items item = collision.GetComponent<items>();
        if (item != null)
        {
            item.Collect();
        }
    }
}
