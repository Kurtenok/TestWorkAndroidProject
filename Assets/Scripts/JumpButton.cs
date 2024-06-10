using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    [SerializeField] CharacterJump characterJump;
    [SerializeField] GradientImage gradientImage;

    [HideInInspector] public Vector3 destination;

    [HideInInspector] public int[] colorPercents;

    
    Button button;

    GameObject Player;

    Health playerHealth;
    
    void Start()
    {
        button = GetComponent<Button>();

        Player=GameObject.FindWithTag("Player");
        if(Player)
        {
            characterJump=Player.GetComponent<CharacterJump>();
            playerHealth=Player.GetComponent<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      // isPressed = true;
    
        //Debug.Log("Button pressed!");
        if(colorPercents.Length>0)
        {
            gradientImage.gameObject.SetActive(true);
            gradientImage.Activate(colorPercents);
        }
    }

    // Вызывается при отпускании кнопки
    public void OnPointerUp(PointerEventData eventData)
    {
       // isPressed = false;
        
       // Debug.Log("Button released!");

        /*if(GetCurrentZone())
        {
        characterJump.SetAgentDestination(destination);
        }
        else
        {
        playerHealth.MinusOneHP();
        Debug.Log("- HP");
        }*/


        switch(GetCurrentZone()) // 1 red 2 yellow 3 green
        {
            case 1:
            playerHealth.MinusOneHP();
            break;

            case 2:
            playerHealth.MinusHalfHP();
            break;

            case 3:
            characterJump.Jump(destination);
            break;
        }

        gradientImage.Deactivate();

    }
    /*void OnPointerDown()
    {
        Debug.Log("Button pressed!");
    }

    void OnPointerUp()
    {
        Debug.Log("Button released!");
    }*/

    int GetCurrentZone()// 1 red 2 yellow 3 green
    {   
        bool biger=(gradientImage.GetProgress()*100)>colorPercents[0]/2+colorPercents[1]/2;
        bool lower=(gradientImage.GetProgress()*100)<100-colorPercents[0]/2-colorPercents[1]/2;
       



        if(biger && lower)
        return 3;
        else
        {
            biger=(gradientImage.GetProgress()*100)>colorPercents[0]/2;
            lower=(gradientImage.GetProgress()*100)<100-colorPercents[0]/2;
            if(biger && lower)
            return 2;
            else
            return 1;
        }

    }
}
