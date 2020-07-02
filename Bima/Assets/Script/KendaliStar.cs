using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KendaliStar : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;

    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;
    }

    public void starsArcheived(){
        int coinleft = GameObject.FindGameObjectsWithTag("coin").Length;
        int coinsCollected = coinsCount - coinleft;

        float precentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString())*100f;

        if (precentage >= 33f && precentage <66){
            stars[0].SetActive(true);
        }else if(precentage >= 66 && precentage < 70){
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }else {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
