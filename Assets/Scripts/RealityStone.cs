using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityStone : Fruit
{
    public int timeInvunerable;

    public override float Effect(GameObject player)
    {
        StartCoroutine(Inbunerable(player));
        return CooldownTime;
    }

    IEnumerator Inbunerable(GameObject player)
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(timeInvunerable);
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
}
