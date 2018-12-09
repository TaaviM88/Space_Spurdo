using System.Collections;       
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerDefaultLifes = 2;
    public float iFrames = 2;
    float countdown;
    bool iFramesCountdown;
    int playerCurrentLifes;
    Jump jump;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentLifes = playerDefaultLifes;
        jump = GetComponent<Jump>();

        if (jump == null)
        {
            Debug.Log("Ei löydy Jump-scriptiä");
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(iFramesCountdown)
        {
            if(countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                iFramesCountdown = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            if (playerCurrentLifes >0 &&iFramesCountdown == false)
            {
                playerCurrentLifes -= 1;
                iFramesCountdown = true;
                countdown = iFrames;
            }

            else
            {
                ResetScene();
            }
            Debug.Log("Osuin");
            
        }

        //Lisää hyppyri tagin tsekkaus
        //Jos tag on hyppyri kutsu jump scriptin  MakeAJump-metodia
        if (collision.gameObject.tag == "Jumper")
        {   
            jump.MakeAJump();
        }

    }

    public int ReturnCurrentLifes()
    {
        return playerCurrentLifes;
    }

    private void ResetScene()
    {
        GameManager.Instance.ResetScene();
    }
}
        