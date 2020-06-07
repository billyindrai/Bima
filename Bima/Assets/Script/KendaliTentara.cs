using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KendaliTentara : MonoBehaviour {

    public GameObject Pemain;

    public AudioSource hit;

    public float BatasKiri;
    public float BatasKanan;
    public float Akselerasi;
    public bool HadapKanan;

    float NilaiPerubahan;
    float Tujuan;

    // public Animator animator;
    public int health = 100;

    private Vector3 startingposition;

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

    // void FixedUpdate() {
    //     if (HadapKanan) {
    //         Tujuan = BatasKanan + 2;
    //     }
    //     else {
    //         Tujuan = BatasKiri - 2;
    //     }


    //     float PosX = Mathf.SmoothDamp(transform.position.x, Tujuan, ref NilaiPerubahan, Akselerasi);
    //     transform.position = new Vector2(PosX, transform.position.y);

    //     if (transform.position.x >= BatasKanan && HadapKanan) {
    //         Berpaling();
    //     }
    //     else if (transform.position.x <= BatasKiri && !HadapKanan) {
    //         Berpaling();
    //     }
    // }

    // void Berpaling() {
    //     HadapKanan = !HadapKanan;

    //     Vector3 Skala = transform.localScale;
    //     Skala.x *= -1;
    //     transform.localScale = Skala;
    // }

    private void OnCollisionEnter2D(Collision2D Kena) {
        Pemain.GetComponent<KendaliPemain>().Heart();
        if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts > 0 ) {
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 1;
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth == 0){
               Pemain.GetComponent<KendaliPemain>().numberOfHearts -= 1;
               Pemain.GetComponent<KendaliPemain>().ResetHealth();
            }
            // hit.Play();

            // animator.SetBool("Hurt",true);
            // if(Pemain.transform.position.x < transform.position.x){
            //     Pemain.GetComponent<KendaliPemain>().Hurt();
            //     animator.SetBool("Hurt",false);
            // }
        }else if (Kena.gameObject.name == Pemain.name && Pemain.GetComponent<KendaliPemain>().numberOfHearts == 0) {
            // Pemain.GetComponent<KendaliPemain>().PemainMati();
            // SceneManager.LoadScene("theend");
            Pemain.GetComponent<KendaliPemain>().currentHealth -= 1;
            Pemain.GetComponent<KendaliPemain>().TakeDamage();
            if(Pemain.GetComponent<KendaliPemain>().currentHealth == 0){
               Pemain.GetComponent<KendaliPemain>().PemainMati();
            }
        }
    }
}
