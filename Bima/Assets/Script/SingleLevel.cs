using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    public Text txtHighScore; 
    private int currentStarsNum = 0;
    public int levelIndex;

    void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString("0");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("map");
    }


    public void PressStartButton(int _starsNum)
    {
        currentStarsNum = _starsNum;

        if (currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

        //BackButton();
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starsNum));
    }
}