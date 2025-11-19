using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public chaser[] enemy; // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sfxManager.Play("wakeUp"); 
            foreach (chaser x in enemy)
            { x.active = true; }
            gameObject.SetActive(false);
        }
    }
}
