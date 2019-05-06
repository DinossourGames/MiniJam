using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    private void Update()
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Player")
        {
            Debug.Log("DAno");
            collision.otherCollider.GetComponent<Player>().TakeDamage(1);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("DAno");
            collision.GetComponent<Player>().TakeDamage(1);
        }
    }
}
