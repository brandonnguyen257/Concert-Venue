using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{

    public bool LED_ScreenIsActive;
    public bool pyroIsActive;
    public bool fogIsActive;
    public bool roofIsActive;
    public bool frontIsActive;
    public bool nextSongTriggered;
    // Start is called before the first frame update
    void Start()
    {
        LED_ScreenIsActive=false;
        pyroIsActive=false;
        fogIsActive=false;
        roofIsActive=false;
        frontIsActive=false;
        nextSongTriggered=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
