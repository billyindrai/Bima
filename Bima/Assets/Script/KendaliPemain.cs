using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KendaliPemain : MonoBehaviour {

    public Rigidbody2D Bodi;

    public Animator animator;

    public GameObject Die;

    public Collider2D Sensor;
    public Collider2D Lantai, ObjekPasif;
    public Collider2D[] Rintangan;

    public Text scoreText,kunciText;

    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart; 

    public float Kecepatan;
    public float TinggiLompatan;

    // public AudioSource jump,ikan,pukul;

    // public GameObject Portal;
    public int TotalCoin,TotalKunci;

    public HealthBar healthBar;

    public int maxHealth = 4;
    public int currentHealth;

    bool HadapKanan = true;
    bool Mendarat = true;
    bool Mendarat1 = true;
    bool Mendarat2 = true;

    int JumlahCoin = 0;
    int JumlahKunci = 0;
    Vector3 posisiAwal;

    
    public void TambahCoin() {
        JumlahCoin += 1;
        scoreText.text = JumlahCoin.ToString("0");
        // ikan.Play();

        // int currentHighScore = PlayerPrefs.GetInt("HighScore",0);
        // int currentScore = JumlahCoin+currentHighScore;
        // PlayerPrefs.SetInt("HighScore",currentScore);

        int Score = PlayerPrefs.GetInt("Score",0);
        int currentScore1 = JumlahCoin;
        PlayerPrefs.SetInt("Score",currentScore1);
    }

    public void TambahKunci() {
        JumlahKunci += 1;
        int Kunci = JumlahKunci;
        kunciText.text = Kunci.ToString("0");
    }

    public void BukaKunci(){
        if(Input.GetKeyDown(KeyCode.F) &&  JumlahKunci == TotalKunci){
            Debug.Log("Buka");
            SceneManager.LoadScene("Menu Utama");
        }
    }

    public void UpdatePosisi(Vector3 Posisi) {
        posisiAwal = Posisi;
    }
    
    public void Start() {
        Bodi = GetComponent<Rigidbody2D>();
        posisiAwal = transform.position;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update() {
        Mendarat = Physics2D.IsTouching(Sensor, Lantai);
        Mendarat1 = Physics2D.IsTouching(Sensor, ObjekPasif);

        for(int i=0; i < Rintangan.Length; i++ ){
            Mendarat2 = Physics2D.IsTouching(Sensor, Rintangan[i]);
                if (Input.GetKeyDown(KeyCode.X) && Mendarat2 == true){
                    animator.SetBool("Jump",true);
                    Bodi.velocity = Vector2.up * TinggiLompatan;
                    // jump.Play();
                } else if (Mendarat2 == true){
                    animator.SetBool("Jump",false);
                }
        }

        if (Input.GetKeyDown(KeyCode.X) && Mendarat == true) {
            animator.SetBool("Jump",true);
            Bodi.velocity = Vector2.up * TinggiLompatan;
            // jump.Play();
        }   else if (Mendarat == true){
            animator.SetBool("Jump",false);
        }   else if (Input.GetKeyDown(KeyCode.X) && Mendarat1 == true){
            animator.SetBool("Jump",true);
            Bodi.velocity = Vector2.up * TinggiLompatan;
            // jump.Play();
        }   else if (Mendarat1 == true){
            animator.SetBool("Jump",false);
        }

        // if (JumlahCoin == TotalCoin) {
        //     Portal.SetActive(true);
        // }      
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
        transform.Rotate(0f, 180f, 0f);
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

    public void TakeDamage()
    {
        healthBar.SetHealth(currentHealth);        
    }

    public void KenaDamage(int damage)
	{
		currentHealth -= damage;
        healthBar.SetHealth(currentHealth); 

		if (numberOfHearts > 0 && currentHealth == 0)
		{
			numberOfHearts -=1;
            PemainMati();
		}else if (numberOfHearts < 0 && currentHealth == 0){
            PemainMati();
        }
	}

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);    
    }

    public void PemainMati() {
        if(numberOfHearts == 0){
            currentHealth -= 4;
            healthBar.SetHealth(currentHealth); 
            Die.GetComponent<Die>().Died();
        }else{
            ResetHealth();
            transform.position = posisiAwal;
            Bodi.velocity = new Vector2(0f, 0f);
        }
    }

     void OnCollisionEnter2D(Collision2D Kena) {
        if (Kena.gameObject.name == "Sensor Lubang" && numberOfHearts > 0) {
            numberOfHearts -= 1;
            PemainMati();
        } else if (Kena.gameObject.name == "Sensor Lubang" && numberOfHearts < 0) {
            PemainMati();
        }
    }
}
