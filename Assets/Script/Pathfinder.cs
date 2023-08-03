using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnermySpawner enermySpawner;
     WaveConfig waveConfig;
    List<Transform> wayPoints;
    int wayPointsIndex=0;

    void Awake(){
        enermySpawner= FindObjectOfType<EnermySpawner>();
    }
    void Start()
    {
        waveConfig=enermySpawner.getCurrenWave();
        wayPoints=waveConfig.GetWayPoint();
        transform.position=wayPoints[wayPointsIndex].position;
    }

   
    void Update()
    {
        FollowPath();
        
    }
    void FollowPath(){
        if(wayPointsIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointsIndex].position;
            float delta=waveConfig.GetmoveSpeed()*Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position==targetPosition){
                wayPointsIndex++;
            }
        } else{
             Destroy(gameObject);
         }
    }
}
