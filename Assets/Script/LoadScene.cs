using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
     void Awake() {
    scoreKeeper= FindObjectOfType<ScoreKeeper>();    
    }
   public void LoadPlay(){
    SceneManager.LoadScene(1);
   }
    public void LoadPlayAgain(){
        scoreKeeper.resetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu(){
        scoreKeeper.resetScore();
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver(){
        StartCoroutine(waitAndLoad("GameOver",2f));
    }
    public void QuitGame(){
        Debug.Log("Quitting the game");
        Application.Quit();
    }
    IEnumerator waitAndLoad(string scenceName,float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scenceName);
    }
}
