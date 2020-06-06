using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KendaliRintangan1 : MonoBehaviour {

    public GameObject Pemain;

    public float BatasBawah;
    public float BatasAtas;
    public float Akselerasi;
    public bool HadapAtas;

    float NilaiPerubahan;
    float Tujuan;

    void FixedUpdate() {
        if (HadapAtas) {
            Tujuan = BatasAtas + 2;
        }
        else {
            Tujuan = BatasBawah - 2;
        }


        float PosY = Mathf.SmoothDamp(transform.position.y, Tujuan, ref NilaiPerubahan, Akselerasi);
        transform.position = new Vector2(transform.position.x, PosY);

        if (transform.position.y >= BatasAtas && HadapAtas) {
            Berpaling();
        }
        else if (transform.position.y <= BatasBawah && !HadapAtas) {
            Berpaling();
        }
    }

    void Berpaling() {
        HadapAtas = !HadapAtas;

        Vector3 Skala = transform.localScale;
        Skala.y *= -1;
        // transform.localScale = Skala;
    }
}
