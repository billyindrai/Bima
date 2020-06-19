using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked; //Default value is false;
    public Image unlockedImage;
    public GameObject[] stars;

    public Sprite starSprite;

    private void Start()
    {
        PlayerPrefs.DeleteAll(); //Delete all buat NEW GAME
    }

    private void Update()
    {
        UpdateLevelImage();//TODO MOve this methode later
        UpdateLevelStatus();//TODO MOve this methode later
    }

    private void UpdateLevelStatus()
    {
        //if the current lv is 5,the pre should be 4
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0)//Jika bintang di level 1 besar dari 0 maka next
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if(!unlocked)//MARKER if unlock is false mean This level is clocked!
        {
            unlockedImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        } //Jika unlock true maka game di jalankan
        else
        {
            unlockedImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }

    }

    public void PressSelection(string _LevelName)//Jika memencet level ini maka akan auto start
    {
        if(unlocked)
        {
            SceneManager.LoadScene(_LevelName);
        }
    }

}
