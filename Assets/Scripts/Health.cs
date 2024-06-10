using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image fullHeartImage;
    [SerializeField] Image halfHeartImage;

    [SerializeField] Transform initialHeartLocation;

    [SerializeField] GameObject youHaveBeenCatchedImage;

    List<Image> HP=new List<Image>();
    Canvas canvas;

    HealthManager healthManager;

    void Start()
    {
        healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
        canvas=GameObject.Find("Canvas").GetComponent<Canvas>();
        HP.Add(initialHeartLocation.gameObject.GetComponent<Image>());
        if(canvas)
        for(int i = 1;i<healthManager.GetCeilCurrentHealth();i++)
        {
            Image image;
            image=(Instantiate(fullHeartImage,canvas.transform));
            image.transform.localPosition=new Vector2((fullHeartImage.rectTransform.rect.width+20)*i+ initialHeartLocation.localPosition.x,initialHeartLocation.localPosition.y);
            HP.Add(image);
            
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinusOneHP()
    {
        if(healthManager.GetCurretHeath()%1==0)
        {
            Image last= HP[HP.Count-1];
            HP.Remove(last);
            Destroy(last.gameObject);
            healthManager.SetCurrentHealth(healthManager.GetCurretHeath()-1);

            
        }
        else
        {
            Image last= HP[HP.Count-1];
            if(healthManager.GetCurretHeath()>1)
            {
                Image previous= HP[HP.Count-2];
                last.transform.localPosition=new Vector2(previous.transform.localPosition.x-20,previous.transform.localPosition.y);
                HP.Remove(previous);
                Destroy(previous.gameObject);
                healthManager.SetCurrentHealth(healthManager.GetCurretHeath()-1);
            }
            else
            {
                healthManager.SetCurrentHealth(0);
                Destroy(last.gameObject);
                Die();
            }
        }

        if(healthManager.GetCurretHeath() <= 0)
        {
            print("Die");
            Die();
        }
       
    }

    public void MinusHalfHP()
    {
       Image last= HP[HP.Count-1];
       HP.Remove(last);
       Image halfHP=Instantiate(halfHeartImage,canvas.transform);
       halfHP.transform.localPosition=new Vector2(last.transform.localPosition.x-20,last.transform.localPosition.y);
       Destroy(last.gameObject);
       healthManager.SetCurrentHealth(healthManager.GetCurretHeath()-0.5f);
       HP.Add(halfHP);

       if(healthManager.GetCurretHeath()<=0)
        Die();
    }
    public void Die()
    {
        Instantiate(youHaveBeenCatchedImage,Camera.main.transform);
    }
}
