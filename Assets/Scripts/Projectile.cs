using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;


    void Start()
    {
        Destroy(gameObject,lifeTime);

    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}
