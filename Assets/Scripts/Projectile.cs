using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

    }

    private void Update()
    {
        //transform.localRotation = Quaternion.Euler(0, 0, 90);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            if (collision.collider.GetComponent<Enemy>() == null)
            {
                collision.collider.GetComponent<RangedEnemy>().TakeDamage(1);
                DestroyProjectile();
            }
            else
            {
                collision.collider.GetComponent<Enemy>().TakeDamage(1);
                DestroyProjectile();
            }
        }
        if (collision.collider.tag == "Env")
        {
            Destroy(collision.collider.gameObject);
            DestroyProjectile();
        }

    }

}
