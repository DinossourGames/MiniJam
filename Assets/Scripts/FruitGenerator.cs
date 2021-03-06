﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitGenerator : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Fruit> fruits;

    public float spawnCooldown;
    private float currentCD;

    // Start is called before the first frame update
    void Start()
    {
        currentCD = Time.time + 21f;
    }

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (fruits.Count > 0)
        {
            if (currentCD <= Time.time)
            {
                currentCD += Time.time + spawnCooldown;
                var fruta = fruits[Random.Range(0, fruits.Count -1)];
                var spawn = spawnPoints[Random.Range(0, spawnPoints.Count -1)];
                Instantiate(fruta, spawn.position, Quaternion.identity);
                fruits.Remove(fruta);
                spawnPoints.Remove(spawn);
                //TODO: Implementar mensagem
            }
        }
    }

}
