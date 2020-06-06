using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KendaliEs : MonoBehaviour
{
    public GameObject Pemain;
    public AudioSource hit;

    private void OnCollisionEnter2D(Collision2D Kena) {
        Pemain.GetComponent<KendaliPemain>().Heart();
        if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts > 0 ) {
            Pemain.GetComponent<KendaliPemain>().numberOfHearts -= 1;
            hit.Play();
        }else if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts == 0) {
            SceneManager.LoadScene("theend");
        }
    }
}
