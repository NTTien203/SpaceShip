using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectTile;
    [SerializeField] float projectTileSpeed=10f;
    [SerializeField] float projectTileLifeTime=5f;
    [SerializeField] float FiringRate=0.2f;
    [Header("AI")]
    [HideInInspector] public bool isFiring;
    Coroutine FiringCoroutine;
    [SerializeField] bool UseAI;
    AudioPlayer AudioShooting;
   
    [SerializeField] float minimumTime=0.2f;

    private void Awake() {
        AudioShooting=FindObjectOfType<AudioPlayer>();
    }
    void Start(){
        if(UseAI){
            isFiring=true;
        }
    }
    void Update(){
        fire();
    }
    void fire(){
        if(isFiring && FiringCoroutine==null){
           FiringCoroutine= StartCoroutine(FireContinuously());
        }else if(!isFiring && FiringCoroutine!=null){
            StopCoroutine(FiringCoroutine);
            FiringCoroutine=null;
        }
        
    }
    IEnumerator FireContinuously(){
        while(true){
            GameObject instance= Instantiate(projectTile,transform.position,Quaternion.identity);
            Rigidbody2D rb= instance.GetComponent<Rigidbody2D>();
            if(rb!=null){
                rb.velocity=transform.up*projectTileSpeed;
            }

            Destroy(instance,projectTileLifeTime);
            AudioShooting.playShootingClip();
            yield return new WaitForSeconds(FiringRate);
        }
    }
     public  float RamdomFiringRate(){
        float FiringRateTime= Random.Range(0.2f+FiringRate,1f-FiringRate);
        return Mathf.Clamp(FiringRateTime,minimumTime,float.MaxValue);
    }
}
