using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bom : MonoBehaviour {

    public GameObject Pemain;

    public AudioSource hit;

    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D Kena) {
        Pemain.GetComponent<KendaliPemain>().Heart();
        if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts > 0 ) {
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 2;
            animator.SetBool("playboom",true);
            hit.Play();
            Destroy(this.gameObject, 0.8f);
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth <= 0){
                Pemain.GetComponent<KendaliPemain>().PemainMati();
                Pemain.GetComponent<KendaliPemain>().numberOfHearts -= 1;   
            }

            // animator.SetBool("Hurt",true);
            // if(Pemain.transform.position.x < transform.position.x){
            //     Pemain.GetComponent<KendaliPemain>().Hurt();
            //     animator.SetBool("Hurt",false);
            // }
        }else if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts == 0) {
            // Pemain.GetComponent<KendaliPemain>().PemainMati();
            // SceneManager.LoadScene("theend");
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 2;
            animator.SetBool("playboom",true);
            hit.Play();
            Destroy(this.gameObject, 0.8f);
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth <= 0){
               Pemain.GetComponent<KendaliPemain>().PemainMati();
            }
        }
    }
}
