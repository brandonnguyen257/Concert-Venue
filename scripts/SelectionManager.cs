using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public string targetTag="target";
    public string grabTag="grabbable";
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection!=null){
            Outline targetOutline=_selection.GetComponent<Outline>();
            targetOutline.OutlineWidth=0; 
            _selection=null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit)){
            var selection=hit.transform;
            if(selection.CompareTag(targetTag)||selection.CompareTag(grabTag)){
                Outline targetOutline=selection.GetComponent<Outline>();
                if(targetOutline!=null){
                    targetOutline.OutlineWidth=7;
                }
                // var selectionRenerer=selection.GetComponent<Renderer>();
                // if (selectionRendere != null){
                //     #selectionRendere.material=;
                // }
                _selection=selection;
            }

        }
    }
}
