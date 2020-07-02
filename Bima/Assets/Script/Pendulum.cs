using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pendulum : MonoBehaviour
{
    public GameObject Pemain;

    public AudioSource hit;

    #region Public Variables
    public Rigidbody2D body2d;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    #endregion

    #region Private Variables

    #endregion

    #region Main Methods

    void Start(){
        body2d = GetComponent<Rigidbody2D>();
        body2d.angularVelocity = velocityThreshold;

    }

    void Update(){
        Push();
    }
    #endregion

    #region Utility Methods
    public void Push(){
        if (transform.rotation.z > 0 && transform.rotation.z < rightPushRange && (body2d.angularVelocity > 0) && body2d.angularVelocity < velocityThreshold){
            body2d.angularVelocity = velocityThreshold;
        }else if (transform.rotation.z < 0 && transform.rotation.z > leftPushRange && (body2d.angularVelocity < 0) && body2d.angularVelocity > velocityThreshold * -1 ){
            body2d.angularVelocity = velocityThreshold * -1;
        }
    }

    #endregion

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
