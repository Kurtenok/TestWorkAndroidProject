using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Tramplin : MonoBehaviour
{
    new BoxCollider collider;

    [SerializeField] float addToJumpScale=0.05f;
    // Start is called before the first frame update
    void Start()
    {
        collider=GetComponent<BoxCollider>();
        collider.isTrigger=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            CharacterJump jump=other.GetComponent<CharacterJump>();
            jump.JumpWindowScale+=addToJumpScale;
            jump.JumpWindowScale=Mathf.Clamp(jump.JumpWindowScale,0.5f,3);
            Destroy(this.gameObject);    
        }
    }
}
