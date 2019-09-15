using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    private int waypointsNumber = 0;
    public bool loop = true;
    public bool stop = false;
    private int direction = 1;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if ((this.transform.position - waypoints[waypointsNumber].transform.position).sqrMagnitude < 0.05f)
            {
                waypoint point = waypoints[waypointsNumber].GetComponent<waypoint>();
                float d = point.ReturnDegree();

                /*if (point.ReturnDirection() == waypoint.direction.Up)
                {
                    playerMovement.RotateShip(true);
                }
                else
                    playerMovement.RotateShip(false);*/


                GetNextIndex();

                //kerrotaan pelaajalle edellisen waypointin rotaatio ja seuraavan waypointin sijainti
                playerMovement.RotateShip(d, waypoints[waypointsNumber].transform.position);
            }
            
        }
    }

    void GetNextIndex()
    {
        if (waypointsNumber == waypoints.Count - 1)
        {
            if (loop == true && stop == false)
            {
                waypointsNumber = 1;
            }

            else if (loop == true && stop == false)
            {
                direction = -1;
            }

            else if (loop == false && stop == true)
            {
                direction = 0;
            }

        }

        if (waypointsNumber == 0)
        {
            direction = 1;
        }

        int i = waypoints.Count;
        if (waypointsNumber < i)
        {
            waypointsNumber += direction;
        }
        else
            waypointsNumber = 0;
        

    }

}
