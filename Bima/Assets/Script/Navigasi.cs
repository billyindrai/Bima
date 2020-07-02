 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigasi : MonoBehaviour
{
    private int currentSceneIndex;
    private int sceneToContinue;
    public void PindahHalaman(string NamaHalaman) {
        SceneManager.LoadScene(NamaHalaman);
    }

    public void doExitGame() {
     Application.Quit();
    }

    public void LoadMainMenu(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);
    }

    public void StartGame(){
        SceneManager.LoadScene(2);
        PlayerPrefs.DeleteAll();
    }

    public void ContinueGame(){
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if(sceneToContinue != 0){
            SceneManager.LoadScene(sceneToContinue);
        }else{
            return;
        }
    }

    
}
