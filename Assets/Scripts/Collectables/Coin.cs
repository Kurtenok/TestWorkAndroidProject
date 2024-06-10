using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))] 
public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    new BoxCollider collider;
    void Start()
    {
        collider=GetComponent<BoxCollider>();
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+1);
            Destroy(this.gameObject);
        }
    }
}
