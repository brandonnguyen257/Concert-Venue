using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRmenuOptions : MonoBehaviour
{
    public EffectsManager effectsManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp=GameObject.Find("EffectsManager");
        effectsManager = temp.GetComponent<EffectsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
