using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public string Name;
    //public string Description;
    public int HealAmmount;
    public int CooldownTime;
    public GameObject particles;



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
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -52);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public virtual float Effect(GameObject player) { return CooldownTime; }
}
