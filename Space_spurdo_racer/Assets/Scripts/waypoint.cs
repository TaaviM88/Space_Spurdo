using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    CylinderScript cylinder;
    public enum direction {Up,Down, Forward, Right, Left, Back };

    public direction changeDirection;

    public direction ReturnDirection()
    {
        return changeDirection;
    }

    private void Start()
    {
        cylinder = GetComponentInParent<CylinderScript>();
    }

    public float ReturnDegree()
    {
        return cylinder.ReturnAngleDegre();
    }
}
