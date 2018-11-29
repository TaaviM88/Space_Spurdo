using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    Rigidbody _rb;
    public TMP_Text speedometer;
    int speed = 0;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speedometer.text = string.Format("{0:0.00}", _rb.velocity.magnitude);
    }
}
