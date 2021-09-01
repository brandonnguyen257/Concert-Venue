using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLaser : MonoBehaviour
{
    private Animator animator;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        animator.speed=0;
        isActive=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("3")){
            isActive=!isActive;
            if(isActive==true){
                animator.speed=1;
            }
            else{
                animator.speed=0;
            }
            
        }
    }
}
