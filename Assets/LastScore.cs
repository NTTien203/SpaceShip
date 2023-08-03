using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LastScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LastscoreUI;
    ScoreKeeper score;
    
    void Start()
    {
        score=FindObjectOfType<ScoreKeeper>();
    }

        void Update()
    {
        LastscoreUI.text=score.getCurrentScore().ToString();
    }
}
