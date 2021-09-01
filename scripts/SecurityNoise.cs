using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityNoise : MonoBehaviour
{
    private AudioSource audioData;
    
    public float soundWait=2.0f;


    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(soundWait<=0f){
            audioData.Play();  
            soundWait=Random.Range(1.5f, 3.0f);
        }

        soundWait-=Time.deltaTime;
    }


}
