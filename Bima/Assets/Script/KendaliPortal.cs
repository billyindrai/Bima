using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KendaliPortal : MonoBehaviour {

    public GameObject Pemain;

    void Start() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Kena) {
        if (Kena.gameObject.name == Pemain.name) {
            //Pemain.GetComponent<KendaliPemain>().UpdatePosisi(this.transform.position);
            //Destroy(this.gameObject, 0.2f);
            Debug.Log("Masuk Portal");
            SceneManager.LoadScene("theend");
        }
    }
}
