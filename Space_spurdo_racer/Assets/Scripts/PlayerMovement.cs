using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float rotateSpeed = 1f;
    public float forwardSpeed = -1f;
    float playerPositionY;
    float maxSpeed = 10;
    
    
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * rotateSpeed;
        verticalMove = Input.GetAxis("Vertical") * forwardSpeed;
        transform.Rotate(Vector3.forward, horizontalMove);
        
        if (_rb.velocity.magnitude < maxSpeed)
        {
            _rb.AddForce(Vector3.forward * verticalMove, ForceMode.Acceleration);
            //
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);   
        }

        Debug.Log(_rb.velocity);
       //transform.Translate(Vector3.forward* verticalMove);

    }
}
