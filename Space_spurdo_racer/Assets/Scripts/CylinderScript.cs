using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour
{
    public enum direction { Up, Down, Forward, Right, Left, Back };

    public direction changeDirection;

    //public GameObject player;
    Transform player;
    public bool firstOne = false;
    public int towerIndex = 20;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameManager.Instance.player.transform;
        
        if (player.transform.position.z > (transform.position.z + 20) || player.transform.position.y > (transform.position.y + 20))
        {
            MoveCylinder();
        }
    }

    public void MoveCylinder()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + towerIndex);
        //transform.Rotate(new Vector3(transform.rotation.x + 180, transform.rotation.y, 0));
        
        switch (changeDirection)
        {
            case direction.Forward:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + towerIndex);
                //transform.Rotate(new Vector3(transform.rotation.x + 180, transform.rotation.y, 0));
                break;
            case direction.Up:
                transform.position = new Vector3(transform.position.x, transform.position.y + towerIndex, transform.position.z);
                //transform.Rotate(new Vector3(transform.rotation.x + 180, transform.rotation.y, 0));
                break;
        }

    }
}
