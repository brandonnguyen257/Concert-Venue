using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Score scoreObject;
    public Transform transform;
    private float xPosition;
    private float yPosition;
    private float zPosition;

    private float ySpawnRange=10.0f;
    private float xSpawnRange=20.0f;
    bool activeTarget;
    float disappear=.2f;
    float timeSinceShot;
    public GameObject target; 

    private GameObject currTarget;

    // Start is called before the first frame update
    void Start()
    {
        activeTarget=true;
        GameObject ScoreCounter=GameObject.Find("ScoreCounter");
        scoreObject = ScoreCounter.GetComponent<Score>();

        xPosition=transform.position.x;
        yPosition=transform.position.y;
        zPosition=transform.position.z-5;
        Debug.Log(xPosition);
        Debug.Log(yPosition);
        Debug.Log(xPosition);
        currTarget=Instantiate(target, new Vector3(xPosition, yPosition, zPosition),  Quaternion.identity);
        currTarget.GetComponent<Transform>().Rotate(0, -90, 0, Space.Self);
    
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreObject.respawn==true){
            respawn();
        }

        if(activeTarget==false && timeSinceShot<0.0f){
            spawn();
        }
        timeSinceShot-=Time.deltaTime;
    }
    public void respawn(){
        scoreObject.respawn=false;
        activeTarget=false;
        timeSinceShot=disappear;
    }

    public void spawn(){
        activeTarget=true;
        Vector3 newPosition= new Vector3(Random.Range(xPosition-xSpawnRange, xPosition+xSpawnRange), Random.Range(yPosition-ySpawnRange, yPosition+ySpawnRange), Random.Range(zPosition, zPosition));
        currTarget=Instantiate(target,newPosition ,  Quaternion.identity);
        currTarget.GetComponent<Transform>().Rotate(0, -90, 0, Space.Self);
    }
}
