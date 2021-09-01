using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningLaser : MonoBehaviour
{
    Renderer rend;
    public Light lightSource;
    Color colorStart = Color.white;
    Color colorEnd = Color.black;
    Color colorRed=Color.red;
    private bool strobeOn;
    private float timePassed;
    private bool strobeActive;

    

    // Start is called before the first frame update
    void Start()
    {
        strobeOn=false;
        strobeActive=false;
        rend = GetComponent<Renderer>();
        lightSource.enabled=false;
        rend.material.SetColor("_EmissionColor", colorEnd);
        timePassed=0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("7")){
            strobeActive=!strobeActive;

            if(strobeActive==true){
                strobeOn=true;
                timePassed=0.0f;
                rend.material.SetColor("_EmissionColor", colorStart);
                lightSource.color=colorStart;
                lightSource.enabled=true;
            }
            else{
                strobeActive=false;
                strobeOn=false;
                rend.material.SetColor("_EmissionColor", colorEnd);
                lightSource.enabled=false;
            }
        }
        if(timePassed>=.1f && strobeActive==true){
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
        
        timePassed+=Time.deltaTime;
    }
}
