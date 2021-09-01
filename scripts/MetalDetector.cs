using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{

    private AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag=="Player"){
            audioData.Play(0);
        }
    }
}
