using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviro : MonoBehaviour
{
    public float speed = 10f;      
    public float lifetime = 5f;   
   

    private void Start()
    {
        Destroy(gameObject, lifetime);
        transform.rotation = Quaternion.Euler(0, 0 , 180);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
