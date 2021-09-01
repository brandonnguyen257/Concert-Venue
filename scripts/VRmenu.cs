using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class VRmenu : MonoBehaviour
{

    public EffectsManager effectsManager;
    public static bool MenuIsActive=false;
    public Transform playerTransform;
    public Canvas canvas;
    Transform canvasTransform;
    public Text scoreText;

    public Score scoreObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();

        GameObject temp1=GameObject.Find("ScoreCounter");
        scoreObject = temp1.GetComponent<Score>();
        canvas=GetComponent<Canvas>();
        canvasTransform=canvas.GetComponent<Transform>();
        canvas.enabled=false;
        GameObject tempPlayer=GameObject.Find("Player");
        playerTransform=tempPlayer.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){
            if(MenuIsActive){
                Resume();
            }
            else{
                Debug.Log("Display Menu");
                //Debug.Log(playerTransform.position.z);
                displayMenu();
            }
        }    
        scoreText.text="Score: "+scoreObject.score.ToString();
    }


    public void displayMenu(){
        canvasTransform.position= new Vector3(playerTransform.position.x,playerTransform.position.y+5,playerTransform.position.z+20);
        MenuIsActive=true;
        canvas.enabled=MenuIsActive;
    }

    public void Resume(){
        MenuIsActive=false;
        canvas.enabled=MenuIsActive;
    }

    public void nextSong(){
        Debug.Log("Next Song Hit");
    }

    public void triggerLED_Screen(){
        effectsManager.LED_ScreenIsActive=!effectsManager.LED_ScreenIsActive;
        Debug.Log(effectsManager.LED_ScreenIsActive);
    }

    public void triggerPyro(){
        Debug.Log("Pyro Button PRessed");
        effectsManager.pyroIsActive=!effectsManager.pyroIsActive;
    }
    public void triggerFog(){
        Debug.Log("Fog Button PRessed");
        effectsManager.fogIsActive=!effectsManager.fogIsActive;
    }

    public void triggerRoof(){
        Debug.Log("Roof Button PRessed");
        effectsManager.roofIsActive=!effectsManager.roofIsActive;
    }
    public void triggerFrontLights(){
        Debug.Log("Front Lights Button PRessed");
        effectsManager.frontIsActive=!effectsManager.frontIsActive;
    }

    public void QuitGame(){
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void triggerNextSong(){
        Debug.Log("Next Song Button PRessed");
        effectsManager.nextSongTriggered=true;
        Debug.Log(effectsManager.nextSongTriggered);
    }
    public void resetScore(){
        Debug.Log("Score Rest");
        scoreObject.score=0;
    }
}
