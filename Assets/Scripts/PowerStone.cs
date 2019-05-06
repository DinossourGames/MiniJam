using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStone : Fruit
{
    public int duration;

    public override float Effect(GameObject player)
    {
        StartCoroutine(Poweeeeer(player));
        return base.Effect(player);
    }

    private IEnumerator Poweeeeer(GameObject player)
    {
        var p = player.GetComponent<Player>();
        player.GetComponent<BoxCollider2D>().isTrigger = true;
        p.isBadas = true;
        yield return new WaitForSeconds(duration);
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        p.isBadas = false;
    }

}
