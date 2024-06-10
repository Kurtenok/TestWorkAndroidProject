using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCountText : MonoBehaviour
{
    // Start is called before the first frame update

    Text text;

    HealthManager healthManager;
    void Start()
    {
       
        text=this.GetComponent<Text>();
        int coins=PlayerPrefs.GetInt("Coins");
        text.text=coins.ToString();
        healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
        healthManager.balanceChanged.AddListener(this.OnBalanceChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBalanceChanged()
    {
        text.text=PlayerPrefs.GetInt("Coins").ToString();
    }
     private void OnEnable()
    {
        if(text){
        int coins=PlayerPrefs.GetInt("Coins");
        text.text=coins.ToString();
        healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
        healthManager.balanceChanged.AddListener(this.OnBalanceChanged);
        }
    }
}
