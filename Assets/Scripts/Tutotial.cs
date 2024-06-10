using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutotial : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<GameObject> tutorialWindows=new List<GameObject>();
    [SerializeField] CharacterJump characterMovement;
    Canvas canvas;

    int currentWindowIndex=-1;
    void Start()
    {
        BlockMovement();

        canvas=GameObject.Find("Canvas").GetComponent<Canvas>();
        foreach(GameObject window in tutorialWindows)
        {
            window.SetActive(false);
        }
        currentWindowIndex=-1;
        OpenNextWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow(bool OpenNext=false)
    {
        GameObject currentwindow=tutorialWindows[currentWindowIndex].gameObject;
        currentwindow.SetActive(false);

        if(OpenNext)
        OpenNextWindow();

       
    }


    public void OpenNextWindow()
    {
        if (tutorialWindows[currentWindowIndex+1])
        {
            GameObject currentwindow=tutorialWindows[currentWindowIndex+1].gameObject;
            currentwindow.SetActive(true);
            currentWindowIndex++;
        }
    }

    public void BlockMovement()
    {
        if(characterMovement)
        {
            characterMovement.movementBlocked=true;
        }   
    }
    public void UnBlockMovement()
    {
        if(characterMovement)
        {
            characterMovement.movementBlocked=false;
        }   
    }
}
