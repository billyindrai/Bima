using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text starsText;

    private void Update()
    {
        UpdateStarsUI();
    }

    private void UpdateStarsUI()
    {
        int sum = 0;

        for(int i = 0; i < 6; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());//Tambah bintang di level1,2dll
        }

        starsText.text = sum + "/" + 15;
    }
}
