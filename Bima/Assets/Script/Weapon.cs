using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject Pemain;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource nembak,habis,peluru;

    public Text ammoText;

    public int maxAmmo = 10;
    private int currentAmmo;

    void Start(){
            currentAmmo = maxAmmo;
            ammoText.text = currentAmmo.ToString("");
    }       

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && currentAmmo > 0){
            Shoot();
            nembak.Play();
        }else if(Input.GetKeyDown(KeyCode.Z) && currentAmmo <= 0){
            habis.Play();
            Debug.Log("Habis");    
        }       
    }

    void Shoot(){
        currentAmmo --;
        ammoText.text = currentAmmo.ToString("0");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void TambahAmmo(){
        currentAmmo += 2;
        peluru.Play();
        ammoText.text = currentAmmo.ToString("0");
    }

}
