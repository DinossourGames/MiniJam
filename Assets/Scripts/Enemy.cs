using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float stopDistance = 1f;
    public int speed;
    private Rigidbody2D rb;

    public float MaxKnockDistance = 10;
    private float atualKnock;
    private Vector2 vetor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        atualKnock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        KnockCheck();

        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {

            if (Vector2.Distance(transform.position, player.position) > stopDistance && player)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Player>().TakeDamage(1);
        }
    }


    private void KnockCheck()
    {
        if (rb.velocity != Vector2.zero)
        {
            if (atualKnock >= MaxKnockDistance)
            {
                atualKnock = 0;
                rb.velocity = Vector2.zero;

            }
            else
            {
                atualKnock = Vector2.Distance(transform.position, player.position);
            }

        }
    }
}
