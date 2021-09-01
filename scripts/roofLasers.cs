using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofLasers : MonoBehaviour
{
    public Renderer rend;
    private Light lightSource;
    private Animator animator;

    private bool isActive;

    public EffectsManager effectsManager;
    bool buttonTrigger;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();
        lightSource=GetComponentInChildren<Light>();
        animator=GetComponent<Animator>();
        rend.material.SetColor("_EmissionColor", Color.black);
        lightSource.enabled=false;
        animator.speed=0;
        isActive=effectsManager.roofIsActive;
        buttonTrigger=effectsManager.roofIsActive;
    }

    // Update is called once per frame
    void Update()
    {
         if(buttonTrigger!=isActive){
            buttonTrigger=isActive;
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
        isActive=effectsManager.roofIsActive;
    }
}
