using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_Screen : MonoBehaviour
{
    Renderer rend;
    public Light lightSource;
    Color colorStart = Color.white;
    Color colorEnd = Color.black;
    Color colorRed=Color.red;
    private bool strobeOn;
    private float timePassed;
    private bool strobeActive;

    public EffectsManager effectsManager;
    bool buttonTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();

        strobeOn=false;
        strobeActive=effectsManager.LED_ScreenIsActive;
        buttonTrigger=effectsManager.LED_ScreenIsActive;

        rend = GetComponent<Renderer>();
        lightSource.enabled=false;
        rend.material.SetColor("_EmissionColor", colorEnd);
        timePassed=0;
    }

    // Update is called once per frame
    void Update()
    {

        if(buttonTrigger!=strobeActive){
            buttonTrigger=strobeActive;
            if(strobeActive){
                
                timePassed=0.0f;
                rend.material.SetColor("_EmissionColor", colorStart);
                lightSource.color=colorStart;
                lightSource.enabled=true;
            }
            else{
                strobeOn=false;
                rend.material.SetColor("_EmissionColor", colorEnd);
                lightSource.enabled=false;
            }
        }

        if(timePassed>=.2f && strobeActive==true){
            strobeOn=!strobeOn;
            timePassed=0.0f;

            if(strobeOn==true){
               rend.material.SetColor("_EmissionColor", colorStart);
               lightSource.color=colorStart;
               lightSource.enabled=true;
               
            }
            else{
                rend.material.SetColor("_EmissionColor", colorEnd);
                lightSource.enabled=false;
            }
        }
        
        strobeActive=effectsManager.LED_ScreenIsActive;
        timePassed+=Time.deltaTime;
    }
}



/*


public class LED_Screen : MonoBehaviour
{
    Renderer rend;
    public Light lightSource;
    Color colorStart = Color.white;
    Color colorEnd = Color.black;
    Color colorRed=Color.red;
    private bool strobeOn;
    private float timePassed;



    // Start is called before the first frame update
    void Start()
    {
        strobeOn=false;
        rend = GetComponent<Renderer>();
        lightSource.enabled=false;
        rend.material.SetColor("_EmissionColor", colorEnd);
        timePassed=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timePassed>=1.0f){
            strobeOn=!strobeOn;
            timePassed=0.0f;

            if(strobeOn==true){
               rend.material.SetColor("_EmissionColor", colorRed);
               lightSource.enabled=true;
               lightSource.color=colorRed;
            }
            else{
                rend.material.SetColor("_EmissionColor", colorEnd);
                lightSource.enabled=false;
            }
        }
        
        timePassed+=Time.deltaTime;
    }
}


*/