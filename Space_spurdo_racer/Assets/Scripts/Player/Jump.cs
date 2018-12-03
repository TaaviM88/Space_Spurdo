using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("jump variables")]
    public float jumpSpeed = 8.0f;
    public float multiplayJumpSpeed = 1;
    public float jumpTime = 3f;
    float countdown;

    float currentYPosition;
    private Vector3 moveDirection = Vector3.zero;
    bool jumping;
    bool canJump = true;
    bool isLanding;

    // Start is called before the first frame update
    void Start()
    {
        countdown = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Hypätään
        if (Input.GetButtonDown("Fire1") && !jumping && canJump)
        {
            currentYPosition = transform.position.y;
            moveDirection.y = jumpSpeed;
            jumping = true;
            canJump = false;
            isLanding = false;
            Debug.Log("Hyppää PERKELE!");
        }


        if(jumping && !isLanding)
        {
            transform.Translate(Vector3.forward * moveDirection.y * Time.deltaTime, Space.Self);
            countdown -= Time.deltaTime;
            if(countdown <= 0.0f)
            {
                countdown = jumpTime;
                isLanding = true;          
            }
        }

        if(jumping && isLanding)
        {
            countdown -= Time.deltaTime;
            transform.Translate(Vector3.forward * (-1 *moveDirection.y * Time.deltaTime), Space.Self);

            if (countdown <= 0.0f)
            {
                countdown = jumpTime;
                isLanding = true;
                jumping = false;
                canJump = true;
            }
        }

        //lisätään korkeutta
       /* if(transform.position.y < currentYPosition + maxHeight && jumping && !isLanding)
        {
            //transform.Translate(new Vector3(transform.position.x, moveDirection.y * jumpSpeed * Time.deltaTime, transform.position.z));
            transform.Translate(Vector3.forward * moveDirection.y * Time.deltaTime,Space.Self);
            Debug.Log("Hypätään niin perkeleesti");
        }

        //Laskeudutaan
        if(transform.position.y > currentYPosition && jumping )
        {

            transform.Translate(Vector3.forward * (fallMultiplayer * Time.deltaTime), Space.Self);
            isLanding = true;
            //isAir = false;
            Debug.Log("Laskeudutaan niin perkeleesti");
        }

        //Chekataan ollaanko maassa
        if(transform.localPosition.y <= currentYPosition && jumping)
        {
            transform.position = new Vector3(transform.position.x, currentYPosition, transform.position.z);
            canJump = true;
            jumping = false;
            Debug.Log("Ollaan maassa niin perkeleesti");
        }

        //chekataan että ollaan pääylösalaisin ja hypätään
        if (transform.position.y < currentYPosition - maxHeight && jumping && !isLanding)
            {
                //transform.Translate(new Vector3(transform.position.x, moveDirection.y * jumpSpeed * Time.deltaTime, transform.position.z));
                transform.Translate(Vector3.forward * ( -1* moveDirection.y * Time.deltaTime), Space.Self);
                Debug.Log("Hypätään niin perkeleesti");
            }
        //moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        */
    }

    public void MakeAJump()
    {
        if (!jumping && canJump)
        {
            currentYPosition = transform.position.y;
            moveDirection.y = jumpSpeed;
            jumping = true;
            canJump = false;
            isLanding = false;
            Debug.Log("Hyppää PERKELE!");
        }
    }
}
