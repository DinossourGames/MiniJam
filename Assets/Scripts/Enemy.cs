using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float stopDistance;
    public int speed;

    private Vector2 vetor;
    public int maxHp;
    public int currentHp;
    public float timeBetweenAttacks;

    public GameObject Confetes;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        collision.collider.GetComponent<Player>().TakeDamage(1);
    //    }
    //}

    public void TakeDamage(int damage)
    {
        if (currentHp > 0)
        {
            currentHp -= damage;
            Debug.Log(currentHp.ToString());
        }
        else
        {
            Instantiate(Confetes, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
 
}
