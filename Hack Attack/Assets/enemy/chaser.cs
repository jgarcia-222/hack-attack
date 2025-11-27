using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class chaser : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public int maxHP = 3;
    private int currentHP;
    private SpriteRenderer spriteRenderer;
    private Color ogColor; //for FlashWhite() function

    public bool active = false; //determines if enemy moves
    public Collider2D enemyTrigger;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ogColor = spriteRenderer.color;
        currentHP = maxHP;

        if (enemyTrigger != null)
        {
             enemyTrigger.isTrigger = true;
        }
    }


    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        if (target && active)
        { rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed; }
        else 
        { rb.velocity = Vector2.zero; }
        spriteRenderer.flipX = rb.velocity.x < 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger touched");
        if (!active && enemyTrigger != null && other.gameObject.tag == "Player")
        {
            active = true;
            //Debug.Log(gameObject.name + " activated by trigger!");
        }
    }

    public void TakeDamage(int damage) //reduce HP when shot
    {
        currentHP -= damage;
        sfxManager.Play("hitEnemy");
        StartCoroutine(FlashOnHit());
        if (currentHP <= 0) //kill unit
        {
            sfxManager.Play("deathEnemy");
            Destroy(gameObject); 
        }
    }

    private IEnumerator FlashOnHit()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = ogColor;
    }
}
