using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterJump : MonoBehaviour
{
    NavMeshAgent agent;
    new Rigidbody rigidbody;
    Camera cam;

    GameObject currentPlatorm;

    float[] ColarPercents=new float[3];
    Coroutine checkPlatfrom;

    [HideInInspector] public float JumpWindowScale=1;

    [SerializeField] LayerMask edgeLayer;
    [SerializeField] GradientImage JumpCheckImage;

    [HideInInspector] public bool movementBlocked=false;

    public bool isInAir=false;
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        agent=GetComponent<NavMeshAgent>();
        cam = Camera.main.GetComponent<Camera>();
        checkPlatfrom=StartCoroutine(checkForCurrentPlatformRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0&& !movementBlocked)
        {
            Touch touch=Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
                //Vector2 Forces=CalculateJumpForce(transform.position,target.position,3);
                //rigidbody.AddForce(Forces*scale);
                Vector3 pos=touch.position;
                Ray ray = cam.ScreenPointToRay(pos);
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                RaycastHit hit;
                int layersToExclude = 1 << LayerMask.NameToLayer("Edge") | 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Tramplin");
                if(Physics.Raycast(ray,out hit, 100,~layersToExclude))
                {
                    if(hit.collider.gameObject==currentPlatorm)
                    {
                        agent.SetDestination(hit.point);
                        if(!CheckPathAvailability())
                        {agent.ResetPath();}
                    }
                }
            }
        }     
    }

     bool CheckPathAvailability()
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 destination = agent.destination;
        bool isPathAvailable = agent.CalculatePath(destination, path);
        return isPathAvailable;
    }

    IEnumerator checkForCurrentPlatformRoutine()
    {
        RaycastHit raycastHit;
        while(true){
        if(Physics.Raycast(this.transform.position,Vector3.down,out raycastHit,2))
        {
            if(raycastHit.collider.gameObject !=currentPlatorm)
            {
                currentPlatorm=raycastHit.collider.gameObject;
                agent.ResetPath();
                isInAir=false;
            }
        }
        yield return new WaitForSeconds(0.2f);
        }
        //PlayerPrefs.SetInt("coin",1);
    }

    public void Jump(Vector3 destination)
    {
        agent.SetDestination(destination);
        isInAir=true;
    }

    public void Jump()
    {
       // JumpCheckImage
    }

    public bool AgentHasPath()
    {
        return agent.hasPath;
    }

}
