using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeToCompleteLevel=120;

    [SerializeField] Text timerText;

    float currentTime;
   
    void Start()
    {
        currentTime=timeToCompleteLevel;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime-=Time.deltaTime;
        timerText.text=currentTime.ToString();

        if(currentTime < 0)
        {
            Health health=GameObject.FindWithTag("Player").GetComponent<Health>();
            health.Die();
        }
    }
}
