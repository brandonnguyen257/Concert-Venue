using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    Score scoreObject;
    public ParticleSystem system;

    bool activeTarget;
    float timeSinceShot;
    float deathAnimTime=.4f;
    float disappear=.2f;
    private AudioSource audioData;
    private Renderer render;

    private ManageEvents manager;

    Color originalColor;
    void Start(){
        timeSinceShot=0f;

        audioData = GetComponent<AudioSource>();
        render= GetComponent<Renderer>();
        originalColor=render.material.color;
        activeTarget=true;
        system.Pause();
        GameObject ScoreCounter=GameObject.Find("ScoreCounter");
        scoreObject = ScoreCounter.GetComponent<Score>();
    }

    void Update(){
        if(activeTarget==false && timeSinceShot<0.0f){
            death();
        }

        if(activeTarget==false && timeSinceShot<disappear){
            render.enabled = false;
        }
        timeSinceShot-=Time.deltaTime;
    }

    public void HoverOver(){
        Color newColor= Color.black;
        render.material.color= newColor;
        render.material.EnableKeyword("_EMISSION");
    }

    public void HoverEnd(){
        render.material.DisableKeyword("_EMISSION");
        render.material.color= originalColor;
    }

    public void Shot(){
        if(activeTarget){
            Debug.Log("Shot");


            if(this.gameObject.name=="targetConcert(Clone)"){
                Debug.Log("targetConcert shot");
                scoreObject.respawn=true;

            }
            scoreObject.score+=1;
            system.Play();
            audioData.Play((ulong).4);
            activeTarget=false;
            timeSinceShot=deathAnimTime;
            
        }
    }

    public void death(){
        Debug.Log("Shot, Score: "+scoreObject.score);
        Destroy(this.gameObject);
    }

}
