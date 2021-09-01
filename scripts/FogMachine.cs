using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMachine : MonoBehaviour
{
    public ParticleSystem system;
    private bool fogActivated;
    private float timeFogActive=0.0f;
    private float fogCoolDown=15.0f;
    private float fogChannelTime=15.0f;
    private bool onCoolDown;
    private float coolDownCounter;
    private AudioSource audioData;
    private float soundLength=5.0f;
    bool buttonTrigger;
    public EffectsManager effectsManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();
        buttonTrigger=effectsManager.fogIsActive;
        audioData = GetComponent<AudioSource>();
        system.Pause();
        fogActivated=effectsManager.fogIsActive;
        onCoolDown=false;

    }


    //#be wary of cases where fogchanneltime is greater than cooldown
    // Update is called once per frame
    void Update()
    {
        if(buttonTrigger!=fogActivated){
            buttonTrigger=fogActivated;
            if(fogActivated==true && !onCoolDown){
                Debug.Log("fog Activated");
                //system.Simulate(3.5f);
                audioData.Play(0);
                system.Play();
                fogActivated=true;
                timeFogActive=0;
                onCoolDown=true;
                coolDownCounter=fogCoolDown;
                
            }
            else if(!fogActivated){
                Debug.Log("fog Channeling for: " + timeFogActive + "s");
            }
            else if(onCoolDown){
                Debug.Log("On Cool Down: "+ coolDownCounter+"s");
            }

        }

        if(fogActivated==true){
            if(timeFogActive>fogChannelTime){
                Debug.Log("End fog");
                system.Stop();
                fogActivated=false;
            }
        }

        timeFogActive+=Time.deltaTime;
        coolDownCounter-=Time.deltaTime;
        fogActivated=effectsManager.fogIsActive;
        if(timeFogActive>=soundLength &&fogActivated==true){
            audioData.Stop();
        }
        if(coolDownCounter<=0.0f && onCoolDown){
            onCoolDown=false;
            Debug.Log("fog Ready");
        }
    }

}
