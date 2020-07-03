using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using UnityEngine.SceneManagement;

public class burung : MonoBehaviour
{
    public GameObject Pemain;
    public int health;
    public int maxHealth;
    public HealthBarBos healthBarUI;
    public Slider slider;

    // Start is called before the first frame update
    public AIPath aiPath;
    void Start (){
        health = maxHealth;
        healthBarUI.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }else if(aiPath.desiredVelocity.x <= 0.01f){
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }

    public void TakeDamage (int damage)
	{
		if(health > 0){
            health -= damage;
            healthBarUI.SetHealth(health); 
        }else if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{	
		Destroy(gameObject);
        SceneManager.LoadScene("01_Level 3");

	}

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
