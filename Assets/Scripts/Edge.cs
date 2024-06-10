using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Edge : MonoBehaviour
{
    EdgesManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager=transform.parent.GetComponent<EdgesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if(manager)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position,1000,1<<gameObject.layer);
                /*foreach(Collider hitCollider in hitColliders)
                {
                    Debug.Log(hitCollider.name);
                }*/

                Collider closest=FindClosestCollider(hitColliders,other.transform.position);
                if(closest!=null)
                {
                    manager.ActivateArrow(closest.transform,transform,other.gameObject);
                }
                else
                {Debug.Log("Could find sloset egde");}
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            if(manager)
            {
                manager.HideArrow();
            }
        }
    }

    public GameObject GetManagerObject()
    {
        return manager.gameObject;
    }

    Collider FindClosestCollider(Collider[] colliders,Vector3 Player)
    {

        
        if(colliders.Length == 0)
        return null;


        List<Collider> colliders1 = new List<Collider>();
        colliders1.AddRange(colliders);

        List<Collider> collidersToRemove=new List<Collider>();
        foreach(Collider collider in colliders1)
        {
            Edge edge=collider.GetComponent<Edge>();
            if(edge.GetManagerObject()==GetManagerObject() || Vector3.Angle(transform.forward,edge.transform.forward)%180>50)
            {
                collidersToRemove.Add(collider);
            }
        }


        foreach(Collider collider in collidersToRemove)
        {
            colliders1.Remove(collider);
        }


        if(colliders1.Count==0)
        return null;

        Collider closestColider=colliders1[0];
        float closestDistance=Vector3.Distance(Player,closestColider.transform.position);

        Collider thisCollider=GetComponent<Collider>();

        foreach(Collider collider in colliders1)
        {
           
                float distance=Vector3.Distance(Player,collider.transform.position);
                if(distance<closestDistance)
                {
                    closestColider=collider;
                    closestDistance=distance;
                }
            
        }
        return closestColider;
    }
}
