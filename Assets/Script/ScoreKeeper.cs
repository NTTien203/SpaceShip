using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
        private int currentScore;
        static ScoreKeeper instance;
    void Awake() {
        manageSingleton();
    }
    
    void manageSingleton(){
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public int getCurrentScore(){
        return currentScore;
    }
    public void setScore(int scorePlus){
        this.currentScore+=scorePlus;
        Mathf.Clamp(currentScore,0,int.MaxValue);
        Debug.Log(currentScore);
    }
    public void resetScore(){
        currentScore=0;
    }
}
