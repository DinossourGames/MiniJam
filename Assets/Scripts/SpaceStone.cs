using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpaceStone : Fruit
{
    public int tpDistance = 15;
    public Transform[] tpPoints;
    public override float Effect(GameObject player)
    {
        player.transform.position = new Vector3(tpPoints[Random.Range(0, tpPoints.Length)].position.x, tpPoints[Random.Range(0, tpPoints.Length)].position.y,player.transform.position.z);
        return CooldownTime;
    }

}


