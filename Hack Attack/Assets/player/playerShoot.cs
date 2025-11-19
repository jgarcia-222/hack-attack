using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0.0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //direction from player to mouse
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        sfxManager.Play("shoot");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y) * bulletSpeed;
        Destroy(bullet, 1f);
    }
}
