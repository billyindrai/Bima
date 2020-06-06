using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text txtHighScore; 

    void Start()
    {
        txtHighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString("0");
    }

    void Update(){
    }
}