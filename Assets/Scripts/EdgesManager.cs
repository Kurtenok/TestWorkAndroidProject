using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EdgesManager : MonoBehaviour
{
    public GameObject arrowButtonPrefab; 

    public float distanceScale=1; 
    private GameObject arrowInstance; 
    private Transform canvasTransform;


    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform; 
    }

    public void ActivateArrow(Transform target, Transform edge, GameObject Player)
    {
        if (arrowButtonPrefab == null)
        {
            Debug.LogError("Arrow prefab is not assigned!");
            return;
        }
        
        CharacterJump jump=Player.GetComponent<CharacterJump>();


        arrowButtonPrefab.SetActive(true);

        /*if (arrowInstance != null)
        {
            Destroy(arrowInstance); 
        }*/

  
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, (target.position+edge.position)/2);

        

       // arrowInstance = Instantiate(arrowButtonPrefab, canvasTransform);
        arrowButtonPrefab.GetComponent<RectTransform>().position = screenPosition;
        //arrowButtonPrefab.transform.Rotate(0, 0, 180);
        Vector2 targetScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);
        Vector2 edgeScreenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, edge.position);

// Находим угол между направлением от arrowButtonPrefab к target и направлением от arrowButtonPrefab к edge
        Vector2 directionToTarget = targetScreenPos - (Vector2)arrowButtonPrefab.transform.position;
        Vector2 directionToEdge = edgeScreenPos - (Vector2)arrowButtonPrefab.transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, directionToTarget - directionToEdge);

// Вращаем arrowButtonPrefab на рассчитанный угол
        arrowButtonPrefab.transform.rotation = Quaternion.Euler(0, 0, angle);



        JumpButton jumpButton=arrowButtonPrefab.GetComponent<JumpButton>();
        jumpButton.destination=target.position;

        
        jumpButton.colorPercents=CalculatePercents(target,edge,jump);
    }

    public void HideArrow()
    {
         if (arrowButtonPrefab == null)
        {
            Debug.LogError("Arrow prefab is not assigned!");
            return;
        }

        arrowButtonPrefab.SetActive(false);
    }

    int[] CalculatePercents(Transform target, Transform edge,CharacterJump characterJump)
    {
        int[] percents   = new int[3];
        percents[2]=(int)(Vector3.Distance(target.position,edge.position)/distanceScale);
        percents[2]=Mathf.Clamp(percents[2], 10,50);
        float per= percents[2]*characterJump.JumpWindowScale;
        percents[2]=(int)per;
        
        //Debug.Log("Green "+percents[2]);
        percents[1]= percents[2]/2;
        percents[0]=100-percents[2]-percents[1];

        return percents;
    }
}