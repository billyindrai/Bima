using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Misi : MonoBehaviour
{
    public static bool GameIsMisi = false;

    public GameObject misiMenuUI;

    void Start(){
        misi();
    }

    void Update(){
        if(GameIsMisi){
            misi();
        }else{
            Resume();
        }
    }

    public void Resume(){
        misiMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsMisi = false;
    }

    void misi(){
        misiMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsMisi = true;
    }
}
