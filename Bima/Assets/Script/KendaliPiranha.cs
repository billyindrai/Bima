using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KendaliPiranha : MonoBehaviour {

    public GameObject Pemain;
    public AudioSource hit;
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
        transform.localScale = Skala;
    }

    private void OnCollisionEnter2D(Collision2D Kena) {
        Pemain.GetComponent<KendaliPemain>().Heart();
        if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts > 0 ) {
            Pemain.GetComponent<KendaliPemain>().numberOfHearts -= 1;
            hit.Play();

            // animator.SetBool("Hurt",true);
            // if(Pemain.transform.position.x < transform.position.x){
            //     Pemain.GetComponent<KendaliPemain>().Hurt();
            //     animator.SetBool("Hurt",false);
            // }
        }else if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts == 0) {
            SceneManager.LoadScene("theend");
        }
    }
}
