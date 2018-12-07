using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    private Image image;
    public TMP_Text speedometer;

    Rigidbody _rb;
    public Rigidbody objectToMeasure;
    
    public float maxVelocity = 10.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        _rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity;
        
        speedometer.text = string.Format("{0:0.00}", _rb.velocity.magnitude);
    }
}
