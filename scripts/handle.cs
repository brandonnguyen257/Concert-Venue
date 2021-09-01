using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    public float groundDistance = 0.4f;
    private AudioSource audioData;
    float deathAnimTime=.5f;
    float timeSinceDropped;
    bool hasDropped;
    // Start is called before the first frame update
    void Start()
    {
        hasDropped=false;
        timeSinceDropped=0f;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceDropped<=0 && hasDropped){
            Destroy(this.gameObject);
        }
        isGrounded= Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        if(isGrounded && hasDropped==false){
            audioData.Play((ulong).5);
            hasDropped=true;
            Debug.Log("broken");
            timeSinceDropped=deathAnimTime;
            
        }
        timeSinceDropped-=Time.deltaTime;
    }
}
