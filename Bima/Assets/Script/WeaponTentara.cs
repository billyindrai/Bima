using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTentara : MonoBehaviour
{   
    public GameObject Pemain, Tentara;
    public Transform firePoint;

    [SerializeField]
    public GameObject bulletPrefab;
    float fireRate;
    float nextFire;


	void Start () {
		fireRate = 1f;
        nextFire = Time.time;
	}

    private void OnTriggerStay2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name){
            Shoot();
        } 
    }
    // Update is called once per frame
    void Update(){
        // Shoot();          
    }

    void Shoot(){
        if(Time.time > nextFire){
            Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
