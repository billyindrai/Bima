using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaraBullet : MonoBehaviour {
	float moveSpeed = 7f;
	public float speed = 20f;
	public int damage = 1;
	public Rigidbody2D rb;

	// public GameObject impactEffect;
	KendaliPemain target;
	Vector2 moveDirection;

	void Start(){
		// rb.velocity = transform.right * speed;
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<KendaliPemain>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
	}


	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		KendaliPemain pemain = hitInfo.GetComponent<KendaliPemain>();
		if (pemain != null)
		{
			pemain.KenaDamage(damage);
		}
	}
	
}