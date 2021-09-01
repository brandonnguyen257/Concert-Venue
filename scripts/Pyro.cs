using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : MonoBehaviour
{
    public ParticleSystem system;
    private bool pyroActivated;
    private float timePyroActive=0.0f;
    public float pyroCoolDown=10.0f;
    public float pyroChannelTime=6.0f;
    private bool onCoolDown;
    private float coolDownCounter;
    private AudioSource audioData;
    public EffectsManager effectsManager;
    // Start is called before the first frame update
    bool buttonTrigger;
    void Start()
    {

        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();
        buttonTrigger=effectsManager.pyroIsActive;
        audioData = GetComponent<AudioSource>();
        system.Pause();
        pyroActivated=effectsManager.pyroIsActive;
        onCoolDown=false;
    }


    //#be wary of cases where pyrochanneltime is greater than cooldown
    // Update is called once per frame
    void Update()
    {
        if(buttonTrigger!=pyroActivated){
            buttonTrigger=pyroActivated;
            if(pyroActivated==true && !onCoolDown){
                Debug.Log("Pyro Activated");
                system.Simulate(2.5f);
                system.Play();
                audioData.Play(0);
                pyroActivated=true;
                timePyroActive=0;
                onCoolDown=true;
                coolDownCounter=pyroCoolDown;
                
            }
            else if(!pyroActivated){
                Debug.Log("Pyro Channeling for: " + timePyroActive + "s");
            }
            else if(onCoolDown){
                Debug.Log("On Cool Down: "+ coolDownCounter+"s");
            }

        }

        if(pyroActivated==true){
            if(timePyroActive>pyroChannelTime){
                Debug.Log("End Pyro");
                system.Stop();
                audioData.Stop();
                //system.Clear();
                pyroActivated=false;
            }
        }

        timePyroActive+=Time.deltaTime;
        coolDownCounter-=Time.deltaTime;
        pyroActivated=effectsManager.pyroIsActive;
        if(coolDownCounter<=0.0f && onCoolDown){
            onCoolDown=false;
            Debug.Log("Pyro Ready");
        }
    }



}
