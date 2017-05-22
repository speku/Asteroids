using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility  {

    public static Vector2 SpawnArea(float cushion)
    {
        var limitVec = Camera.main.ScreenToWorldPoint(Vector2.zero) * -1;
        return new Vector2(limitVec.x + cushion, limitVec.y + cushion);
    }

}
