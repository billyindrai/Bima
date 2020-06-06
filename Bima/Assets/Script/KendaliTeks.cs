using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliTeks : MonoBehaviour {
    public GameObject Pemain;

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            Pemain.GetComponent<KendaliPemain>().TambahTeks();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
