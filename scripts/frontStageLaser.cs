using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontStageLaser : MonoBehaviour
{
    public Renderer rend;
    private Light lightSource;
    private Animator animator;
    private float timePassed;
    private bool isActive;
    private Color currColor;

    public EffectsManager effectsManager;
    bool buttonTrigger;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();
        currColor = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
        lightSource=GetComponentInChildren<Light>();
        animator=GetComponent<Animator>();
        rend.material.SetColor("_EmissionColor", Color.black);
        lightSource.enabled=false;
        animator.speed=0;
        isActive=effectsManager.frontIsActive;;
        buttonTrigger=effectsManager.frontIsActive;
        timePassed=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonTrigger!=isActive){

            buttonTrigger=isActive;
            if(isActive==true){
                rend.material.SetColor("_EmissionColor", currColor);
                lightSource.color=currColor;
                lightSource.enabled=true;
                animator.speed=1;
            }
            else{
                rend.material.SetColor("_EmissionColor", Color.black);
                lightSource.enabled=false;
                animator.speed=0;                
            }
         }

        if(isActive==true && timePassed>=2.0f){
            timePassed=0.0f;
            currColor = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
            rend.material.SetColor("_EmissionColor", currColor);
            lightSource.color=currColor;
        }
        timePassed+=Time.deltaTime;
        isActive=effectsManager.frontIsActive;
    }

    
}
