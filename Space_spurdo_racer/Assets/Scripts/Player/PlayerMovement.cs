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
    float normalMaxSpeed;
    float playerPositionY;
    Vector3 nextWaypoint;
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        normalMaxSpeed = maxSpeed;
        
        //GoToNextPoint();
        //Debug.Log(transform.localEulerAngles);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalMove = Input.GetAxis("Horizontal") * rotateSpeed;
        verticalMove = Input.GetAxis("Vertical") * forwardSpeed;
        transform.Rotate(Vector3.forward, horizontalMove);
        float multiplayerSpeed = 0.1f;
        if (Input.GetButton("Fire2"))
        {
            //maxSpeed *= boostSpeed; 
             multiplayerSpeed = boostSpeed;
        }
        else
        {
            multiplayerSpeed = 0.1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint, verticalMove *multiplayerSpeed);

        if (_rb.velocity.magnitude < maxSpeed)
        {
            //_rb.AddForce(Vector3.forward * verticalMove, ForceMode.Acceleration);

           /*
            if (transform.localEulerAngles.x == 270)
            {
                _rb.AddForce(Vector3.up* verticalMove, ForceMode.Acceleration);
                //_rb.AddForce(Vector3.forward * verticalMove, ForceMode.Acceleration);
            }
            else
            {
                
            }
            */
        }
        else
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);

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

   public void RotateShip(float rotateDegree, Vector3 nextPointPosition)
    {
        
        Debug.Log("Rotate ship " + rotateDegree + "degree");
        transform.localEulerAngles = new Vector3(rotateDegree, transform.localEulerAngles.y, transform.localEulerAngles.z);
        nextWaypoint = nextPointPosition;

        if(rotateDegree != 0)
        {
            /*Vector3 v = _rb.velocity;
            _rb.velocity = Vector3.zero;
            _rb.velocity = new Vector3(v.x, v.z, v.y);*/
        }
        

        /* if(transform.localEulerAngles.y < rotateDegree)
         {
             for(int i = 0; i < rotateDegree; i++)
             {
                 transform.localEulerAngles = new Vector3(i, transform.localEulerAngles.y, transform.localEulerAngles.z);
             }
             //transform.localEulerAngles = new Vector3(270, transform.localEulerAngles.y, transform.localEulerAngles.z);
         }

        Vector3 v = _rb.velocity;
        _rb.velocity = Vector3.zero;
         _rb.velocity = new Vector3(v.x, v.z, v.y);

            Debug.Log("Käännetään alus");
            
        

        if (transform.localEulerAngles.y > rotateDegree)
        {
            if (transform.localEulerAngles.y >= rotateDegree)
                for (int i = (int)rotateDegree; i < 1; i--)
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
        }*/

    }

    public void TurboBoost()
    {

    }
}
