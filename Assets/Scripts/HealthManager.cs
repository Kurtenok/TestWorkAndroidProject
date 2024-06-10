using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    float currentHealth;

    public UnityEvent balanceChanged=new UnityEvent();

    [SerializeField] GameObject notEnoughCoinsImage;
    LevelTranstitonManager levelTranstitonManager;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpgradeMaxHealth(int price)
    {
        if(PlayerPrefs.GetInt("Coins")>=price)
        {
            int count=PlayerPrefs.GetInt("MaxHeath");
            PlayerPrefs.SetInt("MaxHeath", count+1);
            int newHealth=count+1;
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-price);
            currentHealth++ ;
            PlayerPrefs.Save();
            balanceChanged.Invoke();
        }
        else
        {
            notEnoughCoinsImage.SetActive(true);
        }
    }

    public void UpgradeHealthRegen(int price)
    {
        if(PlayerPrefs.GetInt("Coins")>=price)
        {
            int count=PlayerPrefs.GetInt("HealthRegen");
            PlayerPrefs.SetInt("HealthRegen", count+1);
            Debug.Log("HealthRegen upgraded to "+count+1);
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-price);
            PlayerPrefs.Save();
            balanceChanged.Invoke();
        }
        else
        {
            notEnoughCoinsImage.SetActive(true);
        }
    }

    public int GetCeilCurrentHealth()
    {
        return Mathf.CeilToInt(currentHealth);
    } 

    public float GetCurretHeath()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(float health)
    {
        currentHealth = health;
    }

    public void Initialize()
    {
        if(!PlayerPrefs.HasKey("FistLauch"))
        {
            levelTranstitonManager=GameObject.Find("LevelTransitionManager").GetComponent<LevelTranstitonManager>();
            levelTranstitonManager.firstLaunch=true;
            PlayerPrefs.SetInt("MaxHeath", 3);
            PlayerPrefs.SetInt("HealthRegen", 0);
            PlayerPrefs.SetInt("Coins",6);
            PlayerPrefs.SetInt("FistLauch",1);
        }
        currentHealth=PlayerPrefs.GetInt("MaxHeath");
        DontDestroyOnLoad(this.gameObject);
    }

    public void RestoreHealth()
    {
        currentHealth=PlayerPrefs.GetInt("MaxHeath");
    }
}
