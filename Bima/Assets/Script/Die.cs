using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public static bool GameIsDie = false;

    public GameObject dieMenuUI;

    void Start(){
        Resume();
    }

    public void Resume(){
        dieMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsDie = false;
    }

    public void Died(){
        dieMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsDie = true;
    }

    public void Ulangi(){
        SceneManager.LoadScene("stage 1");
    }

    public void Quit(){
        SceneManager.LoadScene("Menu Utama");
    }
}
