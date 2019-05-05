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

    private bool isFacingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHp = maxHp;
        isFacingRight = true;
    }

    void Update()
    {
        CheckLife();
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Z))
            animator.SetTrigger("Provoque");

        if (movement != Vector2.zero)
        {
            if (movement.x < 0)
            {
                isFacingRight = false;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                isFacingRight = true;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            moveAmmount = movement.normalized * speed;
            animator.SetBool("Running", true);

        }
        else
            animator.SetBool("Running", false);
    }

    private void FixedUpdate()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ass"))
            rb.MovePosition(rb.position + moveAmmount * Time.deltaTime);

    }

    private void CheckLife()
    {
        if (currentHp <= 0)
            Die();
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Morreu");
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
