using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0,1)] float Volume=1f;

    [Header("TakeDamage")]
    [SerializeField] AudioClip takeDameClip;

    void Awake() {
        manageSingleton();
    }
    void manageSingleton(){
        int instanceCount=FindObjectsOfType(GetType()).Length;
        if(instanceCount>1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    public void playShootingClip(){
        if(shootingClip!=null){
            AudioSource.PlayClipAtPoint(shootingClip,
            Camera.main.transform.position,
            Volume);
        }
    }
    public void playTakeDamageClip(){
        if(takeDameClip!=null){
            AudioSource.PlayClipAtPoint(takeDameClip,
                                        Camera.main.transform.position,
                                        Volume);
        }
    }
}
