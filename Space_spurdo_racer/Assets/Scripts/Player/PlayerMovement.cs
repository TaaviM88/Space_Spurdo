using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0f;
    float verticalMove = 0f;
    [Header("Movement variables")]
    public float rotateSpeed = 1f;
    public float forwardSpeed = -1f;
    public float boostSpeed = 2f;
    float maxSpeed = 10;
    float playerPositionY;
    
    [Header("Waypoints")]
    /*public GameObject[] waypoints;
    int destPoint = 0;
    Vector3 nextDestination;
    float maxDistance = 0.5f;
    bool IsNear = false;*/
    Rigidbody _rb;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //GoToNextPoint();
        Debug.Log(transform.localEulerAngles);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
 
        horizontalMove = Input.GetAxis("Horizontal") * rotateSpeed;
        verticalMove = Input.GetAxis("Vertical") * forwardSpeed;
        transform.Rotate(Vector3.forward, horizontalMove);

        if (_rb.velocity.magnitude < maxSpeed)
        {
            //Debug.Log(transform.localEulerAngles.x);
            if (transform.localEulerAngles.x == 270)
            {
                _rb.AddForce(Vector3.up* verticalMove, ForceMode.Acceleration);
                //_rb.AddForce(Vector3.forward * verticalMove, ForceMode.Acceleration);
            }
            else
            {
                _rb.AddForce(Vector3.forward * verticalMove, ForceMode.Acceleration);
            }
            
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);   
        }

        //Debug.Log((nextDestination - transform.position).sqrMagnitude + "Mitataan etäisyyttä");

     //tsekkaillaan ollaanko lähellä seuraavaa listan objektin sijaintia
     /*   float distance = Vector3.Distance(transform.localPosition, nextDestination);
        Debug.Log(distance + "Etäisyys");
        IsNear = distance <= maxDistance;

        if (IsNear)
        {
            Debug.Log("seuraava waypoint kiitos");
            GoToNextPoint();
            IsNear = false;
        }

        */
        //Debug.Log(_rb.velocity);
       //transform.Translate(Vector3.forward* verticalMove);

    }

   public void RotateShip(bool rotate)
    {
        if (rotate)
        {
            Debug.Log("Rotate ship 270 degree");

            if(transform.localEulerAngles.y < 270)
            {
                for(int i = 0; i < 270; i++)
                {
                    transform.localEulerAngles = new Vector3(i, transform.localEulerAngles.y, transform.localEulerAngles.z);
                }
                //transform.localEulerAngles = new Vector3(270, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
            
            Vector3 v = _rb.velocity;
            _rb.velocity = Vector3.zero;
            _rb.velocity = new Vector3(v.x, v.z, v.y);

            Debug.Log("Käännetään alus");

        }
        else if (!rotate)
        {
            if (transform.localEulerAngles.y >= 270)
                for (int i = 270; i < 1; i--)
            {
                transform.localEulerAngles = new Vector3(i, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
            }
            
            Debug.Log("set rotation back to 0");
            Debug.Log("Käännetään alus takaisin 0-asteeseen");
        }
        else
        {
            Debug.Log("Do nothing");
        }

    }

    //Method which makes us to go to next waypoint
    /*void GoToNextPoint()
    {
        if(waypoints.Length == 0)
        {
            return;
        }

        nextDestination = waypoints[destPoint].transform.position;
        waypoint point = waypoints[destPoint].GetComponent<waypoint>();

        if(point.ReturnDirection() == waypoint.direction.Up)
        {
            RotateShip(true);

        }
        else if(point.ReturnDirection() == waypoint.direction.Forward)
        {
            RotateShip(false);
        }
        else
        {
            Debug.Log("Do nothing");
        }

        destPoint = (destPoint + 1) % waypoints.Length;

        Debug.Log(destPoint);
    }*/
}
