using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
    public GameObject Pemain;

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            Pemain.GetComponent<Weapon>().TambahAmmo();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
