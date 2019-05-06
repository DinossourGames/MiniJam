using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public int maxHp = 5;
    private int currentHp;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveAmmount;

    private List<Fruit> catchedFruits;
    public Fruit selected;
    float cooldownTime = 0;

    public GameObject armGun;
    public bool isBadas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHp = maxHp;
        catchedFruits = new List<Fruit>();
    }

    void Update()
    {
        CheckLife();
        ChangeFruit();
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Z))
            animator.SetTrigger("Provoque");

        if (movement != Vector2.zero)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

        moveAmmount = movement.normalized * speed;

    }

    private void ChangeFruit()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            int i = catchedFruits.IndexOf(selected);
            if (i == catchedFruits.Count - 1)

                selected = catchedFruits[0];
            else
            {
                i++;
                selected = catchedFruits[i];
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            int i = catchedFruits.IndexOf(selected);
            if (i == 0)

                selected = catchedFruits[catchedFruits.Count - 1];
            else
            {
                i--;
                selected = catchedFruits[i];
            }
        }
    }

    internal void CatchFruit(Fruit fruit)
    {
        catchedFruits.Add(fruit);
        if (selected == null)
        {
            selected = catchedFruits[0];
        }
    }

    internal void Heal(int healAmmount)
    {
        if (currentHp < maxHp)
            currentHp += healAmmount;
        else
            currentHp = maxHp;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (isBadas)
            {
                collision.GetComponent<Enemy>().TakeDamage(500);
            }
        }
    }

    private void FixedUpdate()
    {
        FruitInteractions();

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //pega a posição do mouse na tela
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg); // gera os radiandos pra poder usar na rotação

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ass") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))//são as coisas que são executadas enquanto ele não está duranto provoque
        {
            rb.MovePosition(rb.position + moveAmmount * Time.deltaTime);

            if (angle > -90 && angle < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                armGun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            if (angle < -90 || angle > 90)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                armGun.transform.rotation = Quaternion.Euler(180f, 0f, -(angle));
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

    private void FruitInteractions()
    {
        if (Input.GetMouseButtonDown(1) && cooldownTime <= Time.time)
        {
            cooldownTime = Time.time + selected.Effect(gameObject);
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
    }

    public void Morreu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
