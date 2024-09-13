using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using TMPro;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHealth = 10;
    public float speed = 1.5f;
    private GameManager manager;


    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Die();
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }

    
    public void Die()
    {
        manager.AddPoints(100);
        spawner.EnemyKilled();
        Destroy(gameObject);
    }

    
    private EnemySpawns spawner;  

    void Start()
    {
        spawner = FindObjectOfType<EnemySpawns>(); 
        manager = GameManager.Instance;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

}

