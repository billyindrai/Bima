using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penjara : MonoBehaviour {
    public GameObject Pemain;

    private void OnCollisionEnter2D(Collision2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            Pemain.GetComponent<KendaliPemain>().BukaKunci();
        }
    }
}
