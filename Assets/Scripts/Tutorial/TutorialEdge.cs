using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TutorialEdge : MonoBehaviour
{
    [SerializeField] Tutotial tutotial;
    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("firstTimeEntered",1);
        boxCollider=GetComponent<BoxCollider>();
        boxCollider.isTrigger=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player" && PlayerPrefs.GetInt("firstTimeEntered") == 1)
        {
            tutotial.BlockMovement();
            tutotial.OpenNextWindow(); 
             PlayerPrefs.SetInt("firstTimeEntered",0);
        }
    }

}
