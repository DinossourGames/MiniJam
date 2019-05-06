using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindStone : Fruit
{
    public float controlTime;

    public override float Effect(GameObject player)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(MindSet(enemies));
        return base.Effect(player);
    }

    IEnumerator MindSet(GameObject[] enemies)
    {
        var controle = Random.Range(0, enemies.Length);
        var enemiesList = new List<GameObject>();
        for (int i = 0; i < controle; i++)
        {
            enemiesList.Add(enemies[Random.Range(0,enemies.Length)]);
        }
        enemiesList.ForEach(i => {
            i.tag = "Player";
        });
        yield return new WaitForSeconds(controlTime);
        try
        {
            enemiesList.ForEach(i =>
            {
                i.tag = "Enemy";
            });
        }catch{ }
    }
}
