using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerigi : MonoBehaviour
{
    public GameObject Pemain;
    public AudioSource hit;

    private void OnCollisionEnter2D(Collision2D Kena) {
        Pemain.GetComponent<KendaliPemain>().Heart();
        if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts > 0 ) {
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 1;
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth <= 0){
                Pemain.GetComponent<KendaliPemain>().PemainMati();
                Pemain.GetComponent<KendaliPemain>().numberOfHearts -= 1;   
            }
            // hit.Play();

            // animator.SetBool("Hurt",true);
            // if(Pemain.transform.position.x < transform.position.x){
            //     Pemain.GetComponent<KendaliPemain>().Hurt();
            //     animator.SetBool("Hurt",false);
            // }
        }else if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts == 0) {
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 1;
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth <= 0){
               Pemain.GetComponent<KendaliPemain>().PemainMati();
            }
        }
    }
}
