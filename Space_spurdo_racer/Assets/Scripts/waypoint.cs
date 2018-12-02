using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public enum direction {Up,Down, Forward, Right, Left, Back };

    public direction changeDirection;

    public direction ReturnDirection()
    {
        return changeDirection;
    }
}
