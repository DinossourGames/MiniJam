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

    private void Update()
    {
        if (player != null)
        {


            Vector2 direction = player.position - transform.position;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // gera os radiandos pra poder usar na rotação



            if (angle > -90 && angle < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (angle < -90 || angle > 90)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);

            }
        }
    }

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
