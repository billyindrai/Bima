using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	int damage = 1;
	public Rigidbody2D rb;
	// public GameObject impactEffect;

	void Start () {
		rb.velocity = transform.right * speed;
	}

	private void OnTriggerExit2D (Collider2D hitInfo)
	{
		KendaliTentara tentara = hitInfo.GetComponent<KendaliTentara>();
		if (tentara != null)
		{
			tentara.TakeDamage(damage);
		}
		// Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);

		KendaliBos bos = hitInfo.GetComponent<KendaliBos>();
		if (bos != null){
			bos.TakeDamage(2);
		}
		Destroy(gameObject);

		burung burung = hitInfo.GetComponent<burung>();
		if (burung != null){
			burung.TakeDamage(3);
		}
		Destroy(gameObject);
	}
	
}