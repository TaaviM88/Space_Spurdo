using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    bool isPlayerAlive;
    bool isCounterOn;
    public float counterTime = 3;
    float currentCounter;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

        if(player != null)
        {
            isPlayerAlive = true;
        }
        else
        {
            Debug.Log("Ei löytynyt" + player.name);
        }

        currentCounter = counterTime;
    }

    public void Update()
    {
        if(isCounterOn)
        {
            if(currentCounter > 0)
            {
                currentCounter -= Time.deltaTime;
            }
            else
            {
                isCounterOn = false;
            }
            
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }

    public void StartTimer()
    {
        currentCounter = counterTime;
        isCounterOn = true;
    }
}