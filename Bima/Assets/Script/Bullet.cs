using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb;
	// public GameObject impactEffect;

	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerExit2D (Collider2D hitInfo)
	{
		KendaliTentara tentara = hitInfo.GetComponent<KendaliTentara>();
		if (tentara != null)
		{
			tentara.TakeDamage(damage);
		}
		// Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}