using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTentara : MonoBehaviour
{
    public GameObject Tentara;
    public Transform firePoint;
    public GameObject bulletPrefab;

   
    // Update is called once per frame
    void Update(){
        Shoot();          
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
