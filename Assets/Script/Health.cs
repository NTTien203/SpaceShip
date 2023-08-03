using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health=50;
    [SerializeField] int scorePlus=50;
    [SerializeField] ParticleSystem explodeEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake camerashake;
    AudioPlayer takeDameAudio;
    ScoreKeeper score;
    LoadScene levelManager;

    void Awake() {
        camerashake=Camera.main.GetComponent<CameraShake>();
        takeDameAudio=FindObjectOfType<AudioPlayer>();
        score=FindObjectOfType<ScoreKeeper>();
        levelManager=FindObjectOfType<LoadScene>();
    }
     void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer= other.GetComponent<DamageDealer>();
        if(damageDealer !=null){
            explode();
            damageDealer.Hit();
            ShakeCamera();
            TakeDamage(damageDealer.GetDamage());
        }   
    }
    public void TakeDamage(int damage){
        takeDameAudio.playTakeDamageClip();
        health-=damage;
        if(health<=0){
            if(!isPlayer){
                score.setScore(scorePlus);
            }
            Destroy(gameObject);
            levelManager.LoadGameOver();
        }
    }
    public void explode(){
        if(explodeEffect!=null){
            ParticleSystem instance = Instantiate(explodeEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera(){
        if(camerashake!=null && applyCameraShake){
            camerashake.Play();
        }
    }
    public int getHealth(){
        return health;
    }
}
