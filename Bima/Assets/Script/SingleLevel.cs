using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    public GameObject[] stars;
    public Text txtHighScore; 
    private int currentStarsNum = 0;
    public int levelIndex;

    private int _starsNum;

    void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("Score",0).ToString("0");
        PressStartButton();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("00_Level Selection");
    }


    public void PressStartButton()
    {
        PlayerPrefs.SetInt("Score",_starsNum);
        if (_starsNum <= 5){
            stars[0].SetActive(true);
            currentStarsNum += 1;
        }else if(_starsNum >= 6 && _starsNum <= 15){
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            currentStarsNum += 2;
        }else if(_starsNum >=16) {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            currentStarsNum += 3;
        }

        if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, currentStarsNum);
        }

        //BackButton();
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, currentStarsNum));
    }
}