﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10;
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    // Update is called once per frame
    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }

    private void DamageEnemy(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
