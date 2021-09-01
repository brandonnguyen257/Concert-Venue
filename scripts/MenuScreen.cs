using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScreen : MonoBehaviour
{

    public string startScene;
    public static bool GameIsMainMenu=false;
    public GameObject mainMenuUI;
    bool startSceneLoaded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void StartGame(){
        SceneManager.LoadScene(startScene);
        
        
    }

    public void Quit(){
        Debug.Log(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
