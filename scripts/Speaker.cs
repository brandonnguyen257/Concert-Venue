using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    public AudioSource audio_;
    public MusicManager manager;
    private float nextSongWait=.1f;
    private bool nextSongTriggered;
    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        nextSongTriggered=false;
        elapsedTime=0.0f;
        manager=GetComponentInParent<MusicManager>();
        audio_=GetComponent<AudioSource>();
        int currSong=manager.currSong;

        audio_.clip=manager.songs[currSong].clip;
        audio_.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            elapsedTime=nextSongWait;
            nextSongTriggered=true;
        }    


        elapsedTime-=Time.deltaTime;
        if(elapsedTime<=0.0f && nextSongTriggered==true){
            int currSong=manager.currSong;
            audio_.clip=manager.songs[currSong].clip;
            audio_.Play();
            nextSongTriggered=false;
        }
    }
}
