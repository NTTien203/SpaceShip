using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health displayHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper displayScore;
    void Awake() {
        displayScore=FindObjectOfType<ScoreKeeper>();
    }
    
    void Start()
    {
        healthSlider.maxValue=displayHealth.getHealth();
    }

    
    void Update()
    {
        healthSlider.value=displayHealth.getHealth();
        scoreText.text= displayScore.getCurrentScore().ToString("0000000000");
    }
}
