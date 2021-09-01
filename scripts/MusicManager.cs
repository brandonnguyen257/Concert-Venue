using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public Song[] songs;
    public int currSong;
    int i=0;
    public EffectsManager effectsManager;

    // Start is called before the first frame update
    void Awake(){
        foreach (Song s in songs){
            s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            s.number=i.ToString();
            i++;
        }
        currSong=UnityEngine.Random.Range(0,songs.Length);

    }

    void Start(){
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();        

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("here");

            int nextSong=UnityEngine.Random.Range(0,songs.Length);
            currSong=nextSong;
        }
    }
}
