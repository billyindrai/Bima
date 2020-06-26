using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    float akhir = 0f;
    float awal = 180f;

    [SerializeField] Text countdown;
   
    void Start()
    {
        akhir = awal;
    }

  
    void Update()
    {
        akhir -= 1 *Time.deltaTime;
        countdown.text = akhir.ToString("0");

        if(akhir <= 0){
            akhir = 0;
            // SceneManager.LoadScene("theend");
        }
    }
}
