using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class controller : MonoBehaviour
{
    public GameObject rightController;
    XRRayInteractor rayInteractor;
    // Start is called before the first frame update
    void Start()
    {
        rayInteractor = rightController.GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
