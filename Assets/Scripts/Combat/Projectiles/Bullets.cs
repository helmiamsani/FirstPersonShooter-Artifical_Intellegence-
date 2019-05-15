﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : Projectile
{
    public float speed = 10f;
    public Transform line;
    public GameObject effectPrefab;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if velocity is not zero
        if(rigid.velocity.magnitude > 0f)
        {
            // Rotate using LookRotation: 
            line.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        // If there is an attached effect
        if (effectPrefab)
        {
            // Get the contact point
            ContactPoint contact = col.contacts[0];
            // Spawn the effect - and rotate to contact normal
            Instantiate(effectPrefab, contact.point, Quaternion.LookRotation(contact.normal));
        }
        // Destroy self - "Hello darkness my old friend"
        Destroy(gameObject);
    }

    public override void Fire(Vector3 lineOrigin, Vector3 direction)
    {
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        line.position = lineOrigin;
    }
    
}
