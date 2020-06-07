using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject Pemain;
    public Transform firePoint;
    public GameObject bulletPrefab;

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
        }else if(Input.GetKeyDown(KeyCode.Z) && currentAmmo <= 0){
            Debug.Log("Habis");    
        }       
    }

    void Shoot(){
        currentAmmo --;
        ammoText.text = currentAmmo.ToString("0");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void TambahAmmo(){
        currentAmmo += 1;
        ammoText.text = currentAmmo.ToString("0");
    }

}
