using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : MonoBehaviour
{

    [SerializeField] float TimeBetweenWaves;
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool isLooping;
     WaveConfig currentWave;
    public WaveConfig getCurrenWave(){
        return currentWave;
    }
    IEnumerator waveBettweenWave(){
        do{
            for(int i=0; i<waveConfigs.Count;i++){
                currentWave=waveConfigs[i];
            for(int j=0;j<currentWave.GetEnermyCount();j++){
         Instantiate(currentWave.GetEnermyPrefab(j),
                    currentWave.GetStartingWayPoint().position,
                    Quaternion.Euler(0,0,180),
                    transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
            yield return new WaitForSeconds(TimeBetweenWaves);
        }
        }while(isLooping);
    }
    void Start()
    {
       StartCoroutine(waveBettweenWave());
     
    }
}

