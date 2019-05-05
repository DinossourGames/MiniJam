using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                //cameraAnim.SetTrigger("shake");
                shotTime = Time.time + timeBetweenShots;
            }
        }


    }
}
