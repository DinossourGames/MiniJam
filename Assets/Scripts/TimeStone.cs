using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeStone : Fruit
{
    public float controlTime;

    public override float Effect(GameObject player)
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        StartCoroutine(MindSet(enemies));
        return base.Effect(player);
    }

    IEnumerator MindSet(List<GameObject> enemies)
    {
        enemies.ForEach(i => {
            var enemy = i.GetComponent<Enemy>();
            enemy.speed -= enemy.speed / 2;
        });
        yield return new WaitForSeconds(controlTime);
        try
        {
            enemies.ForEach(i =>
            {
                var enemy = i.GetComponent<Enemy>();
                enemy.speed += enemy.speed * 2;
            });
        }
        catch { }
    }
}
