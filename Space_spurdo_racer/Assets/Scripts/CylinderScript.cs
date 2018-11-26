using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour
{
    public GameObject player;
    public bool firstOne = false;
    public int towerIndex = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > (transform.position.z + 30))
        {
            MoveCylinder();
        }
    }

    public void MoveCylinder()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + towerIndex);
        transform.Rotate(new Vector3(transform.rotation.x + 180, transform.rotation.y, 0));


    }
}
