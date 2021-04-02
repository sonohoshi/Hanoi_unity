using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public override bool Equals(object other)
    {
        if (!(other is Ball ball)) return false;
        return ball.name.Equals(gameObject.name);
    }
}
