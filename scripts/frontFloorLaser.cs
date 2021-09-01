using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontFloorLaser : MonoBehaviour
{
    public Renderer rend;
    private Light lightSource;
    private Animator animator;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
        lightSource=GetComponentInChildren<Light>();
        animator=GetComponent<Animator>();
        rend.material.SetColor("_EmissionColor", Color.black);
        lightSource.enabled=false;
        animator.speed=0;
        isActive=false;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown("4")){
            isActive=!isActive;

            if(isActive==true){
                rend.material.SetColor("_EmissionColor", Color.white);
                lightSource.enabled=true;
                animator.speed=1;
            }
            else{
                rend.material.SetColor("_EmissionColor", Color.black);
                lightSource.enabled=false;
                animator.speed=0;                
            }
         }
        
    }
}
