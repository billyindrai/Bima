using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject pengaturanMenuUI;

    public void Start(){
        pengaturanMenuUI.SetActive(false);
    }

    public void SetVolume(float volume){
        pengaturanMenuUI.SetActive(true);
        Debug.Log(volume);
    }


}
