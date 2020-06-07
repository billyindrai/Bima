﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaraBullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 1;
	public Rigidbody2D rb;
	// public GameObject impactEffect;

	void Start () {
		rb.velocity = transform.right * speed;
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