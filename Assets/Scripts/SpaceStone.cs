using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    class SpaceStone : Fruit
    {

        public override float Effect(GameObject player)
        {

            player.transform.position = Vector2.zero;
            return CooldownTime;
        }

    }

}
