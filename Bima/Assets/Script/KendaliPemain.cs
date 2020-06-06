using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KendaliPemain : MonoBehaviour {

    public Rigidbody2D Bodi;

    public Animator animator;

    public Collider2D Sensor;
    public Collider2D Lantai, ObjekPasif;
    public Collider2D[] Rintangan;

    public Text scoreText;

    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart; 

    public float Kecepatan;
    public float TinggiLompatan;

    public AudioSource jump,ikan,pukul;

    public GameObject Portal;
    public int TotalTeks;

    bool HadapKanan = true;
    bool Mendarat = true;
    bool Mendarat1 = true;
    bool Mendarat2 = true;

    int JumlahTeks = 0;
    
    Vector3 posisiAwal;

    
    public void TambahTeks() {
        JumlahTeks += 1;
        scoreText.text = JumlahTeks.ToString("0");
        ikan.Play();

        int currentHighScore = PlayerPrefs.GetInt("HighScore",0);
        int currentScore = JumlahTeks+currentHighScore;
        PlayerPrefs.SetInt("HighScore",currentScore);

        int Score = PlayerPrefs.GetInt("Score",0);
        int currentScore1 = JumlahTeks;
        PlayerPrefs.SetInt("Score",currentScore1);
    }
    public void UpdatePosisi(Vector3 Posisi) {
        posisiAwal = Posisi;
    }
    
    public void Start() {
        Bodi = GetComponent<Rigidbody2D>();
        posisiAwal = transform.position;
    }

    void Update() {
        Mendarat = Physics2D.IsTouching(Sensor, Lantai);
        Mendarat1 = Physics2D.IsTouching(Sensor, ObjekPasif);

        for(int i=0; i < Rintangan.Length; i++ ){
            Mendarat2 = Physics2D.IsTouching(Sensor, Rintangan[i]);
                if (Input.GetKeyDown(KeyCode.Space) && Mendarat2 == true){
                    animator.SetBool("Jumping",true);
                    Bodi.velocity = Vector2.up * TinggiLompatan;
                    jump.Play();
                } else if (Mendarat2 == true){
                    animator.SetBool("Jumping",false);
                }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Mendarat == true) {
            animator.SetBool("Jumping",true);
            Bodi.velocity = Vector2.up * TinggiLompatan;
            jump.Play();
        }   else if (Mendarat == true){
            animator.SetBool("Jumping",false);
        }   else if (Input.GetKeyDown(KeyCode.Space) && Mendarat1 == true){
            animator.SetBool("Jumping",true);
            Bodi.velocity = Vector2.up * TinggiLompatan;
            jump.Play();
        }   else if (Mendarat1 == true){
            animator.SetBool("Jumping",false);
        }

        if (JumlahTeks == TotalTeks) {
            Portal.SetActive(true);
        }      

        if (Input.GetButtonDown("Fire1")) {
            pukul.Play();
            animator.SetBool("Pukul",true);
        } else {
            animator.SetBool("Pukul",false);
        }
    }

    void FixedUpdate() {
        float Akselerasi = Input.GetAxis("Horizontal");
        Bodi.velocity = new Vector2(Akselerasi * Kecepatan, Bodi.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(Akselerasi));

        if(Akselerasi > 0 && HadapKanan == false) {
            Berpaling();
        }
        else if(Akselerasi < 0 && HadapKanan == true) {
            Berpaling();
        }

        Heart();
    }

    void Berpaling() {
        HadapKanan = !HadapKanan;

        Vector3 Skala = transform.localScale;
        Skala.x *= -1;
        transform.localScale = Skala;
    }

    public void Heart(){
        for (int i=0; i< hearts.Length; i++){
            if(i < numberOfHearts){
                hearts[i].enabled = true;
            }else {
                hearts[i].enabled = false;
            }
        }
    }

    // public void Hurt(){
    //     Bodi.velocity = new Vector2(-10f, Bodi.velocity.y);
    // }

    public void PemainMati() {
        transform.position = posisiAwal;
        Bodi.velocity = new Vector2(0f, 0f);
    }

     void OnCollisionEnter2D(Collision2D Kena) {
        if (Kena.gameObject.name == "Sensor Lubang" && numberOfHearts > 0) {
            numberOfHearts -= 1;
            PemainMati();
        } else if (Kena.gameObject.name == "Sensor Lubang" && numberOfHearts == 0) {
            SceneManager.LoadScene("theend");
        }
    }
}
