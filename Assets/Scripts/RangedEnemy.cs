using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    public GameObject enemyBullet;
    public Transform shotPoint;

    float attackTime;
    Animator anim;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        currentHp = maxHp;
    }


    private void Update()
    {
        if (player != null)
        {

            Vector2 direction = player.position - shotPoint.position;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // gera os radiandos pra poder usar na rotação



            if (angle > -90 && angle < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (angle < -90 || angle > 90)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                
            }


            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                               


                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);

            }


            if (Time.time >= attackTime)
            {
                attackTime = Time.time + timeBetweenAttacks;
                anim.SetTrigger("attack");
            }


        }
    }


    public void RangedAttack()
    {

        if (player != null)
        {


            Vector2 direction = player.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);

        }

    }


}