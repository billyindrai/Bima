using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text txtScore; 

    void Start()
    {
        txtScore.text = PlayerPrefs.GetInt("Score",0).ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
