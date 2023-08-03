
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New WaveConfig", menuName = "WaveConfigg")]
public class WaveConfig : ScriptableObject 
{
    [SerializeField] List<GameObject> enermies;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed=6f;
    [SerializeField] float timeBetweenEnermySpawns=1f;
    [SerializeField] float spawnTimeVariance=0;
    [SerializeField] float minimumSpawnTime=0.2f;
    public float GetmoveSpeed(){
        return moveSpeed;
    }
    public Transform GetStartingWayPoint(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWayPoint(){
        List<Transform> wayPoints= new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public int GetEnermyCount(){
        return enermies.Count;
    }
    public GameObject GetEnermyPrefab(int index){
        return enermies[index];
    }
    public float GetRandomSpawnTime(){
        float spawnTime= Random.Range(timeBetweenEnermySpawns-spawnTimeVariance,
                                     timeBetweenEnermySpawns+spawnTimeVariance );
        return Mathf.Clamp(spawnTime,minimumSpawnTime,float.MaxValue);                           

    }
}

    

