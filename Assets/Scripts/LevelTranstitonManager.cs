using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTranstitonManager : MonoBehaviour
{
    List<string> scenes = new List<string>();

    [SerializeField] GameObject loadingScreenPrefab;
    int scenesCount;
    int currentLevelIndex=0;

    [HideInInspector] public bool firstLaunch=false;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);


        scenesCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
       
        for( int i = 1; i < scenesCount; i++ )
        {
	        scenes.Add(System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) ));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel()
    {
        Canvas canvas=GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject loadscreen=Instantiate(loadingScreenPrefab,canvas.transform);
        loadscreen.transform.SetParent(null);
        canvas.gameObject.SetActive(false);

        LoadingScreen screen= loadscreen.GetComponent<LoadingScreen>();
        if(currentLevelIndex+1!=scenesCount)
        {
            if(currentLevelIndex==0)
            {
                if(firstLaunch)
                {
                    screen.Load(scenesCount-1);
                    scenesCount--;
                }
                else
                {
                    screen.Load(currentLevelIndex+1);
                    
                }
                currentLevelIndex++;
            }
            
        }
        else
        {
            int level=(int)Mathf.Ceil(scenesCount/2);
            currentLevelIndex=level;
            screen.Load(level);
        }    
    }

    public void GoToMenu()
    {
        GameObject losescreen=GameObject.Find("LoseScrin");
        if(losescreen)
        losescreen.SetActive(false);

        Canvas canvas=GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject loadscreen=Instantiate(loadingScreenPrefab,canvas.transform);
        loadscreen.transform.SetParent(null);
        canvas.gameObject.SetActive(false);

        HealthManager healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
        healthManager.RestoreHealth();

        LoadingScreen screen= loadscreen.GetComponent<LoadingScreen>();
        screen.Load(0);
    }

}
