using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public string menu;
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;

    // Update is called once per frame

    void Start(){

    }
    void Update()
    {
        if(Input.GetKeyDown("p")){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
        
    }

    public void Resume(){
        Debug.Log("Resume Button Hit");
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.volume  =  1.0f;
        Time.timeScale=1f;
        GameIsPaused=false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.volume  =  .2f;
        Time.timeScale=0f;
        GameIsPaused=true;
    }

    public void LoadMenu(){
        Time.timeScale=1f;
        pauseMenuUI.SetActive(false);
        Debug.Log("Loading Menu...");
        GameIsPaused=false;
        SceneManager.LoadScene(menu);
    }

    public void QuitGame(){
        Debug.Log("Quitting Game...");
        GameIsPaused=false;
        Application.Quit();
    }
}
