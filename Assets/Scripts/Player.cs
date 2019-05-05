using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public int maxHp = 5;
    private int currentHp;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveAmmount;


    public GameObject armGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHp = maxHp;
    }

    void Update()
    {
        CheckLife();
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Z))
            animator.SetTrigger("Provoque");

        if (movement != Vector2.zero)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

        moveAmmount = movement.normalized * speed;

    }

    private void FixedUpdate()
    {

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //pega a posição do mouse na tela
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // gera os radiandos pra poder usar na rotação

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ass"))//são as coisas que são executadas enquanto ele não está duranto provoque
        {
            rb.MovePosition(rb.position + moveAmmount * Time.deltaTime);

            if (angle > -90 && angle < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                armGun.transform.rotation = Quaternion.Euler(0f, 0f, angle + 45);
            }
            if (angle < -90 || angle > 90)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                armGun.transform.rotation = Quaternion.Euler(180f, 0f, -(angle - 45));
            }
        }
        else // é tudo aquilo que é executado enquanto ele está na animação de provoque
        {
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

    private void CheckLife()
    {
        if (currentHp <= 0)
            Die();
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (maxHp > 0)
        {
            currentHp -= damage;
            Debug.Log(currentHp.ToString());
        }

    }
}
