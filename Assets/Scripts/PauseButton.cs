using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameIsPaused=false;

    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject unpauseButton;
    void Start()
    {   
        pauseButton.SetActive(true);
        unpauseButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        if(!gameIsPaused)
        {
        gameIsPaused=true;
        Time.timeScale=0;
        pauseButton.SetActive(false);
        unpauseButton.SetActive(true);
        }
        else
        {
        
        Time.timeScale=1;
        gameIsPaused=false;
        pauseButton.SetActive(true);
        unpauseButton.SetActive(false);
        }
    }




  
}
