using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public string Name;
    //public string Description;
    public int HealAmmount;
    public int CooldownTime;
    public Rigidbody2D rb;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<Player>();
            player.Heal(HealAmmount);
            player.CatchFruit(this);
            DestroyFruit();
        }
    }

    private void DestroyFruit()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public virtual float Effect(GameObject player) { return CooldownTime; }
}
