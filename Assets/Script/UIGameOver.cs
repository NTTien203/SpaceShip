using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
   ScoreKeeper scoreKeeper;
    void Awake() {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();

    }
    private void Start() {
        scoreText.text="YOUR SCORE\n"+scoreKeeper.getCurrentScore();
    }
    
    
}
