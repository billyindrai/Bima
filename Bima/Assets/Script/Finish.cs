using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    public GameObject Pemain;
    public AudioSource finish;

    void Start() {
    }

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            finish.Play();
            SceneManager.LoadScene("win");
        }
    }
}
