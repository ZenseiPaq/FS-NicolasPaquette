using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : MonoBehaviour
{
    public GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            manager.YouLost();
            EnemyBehavior behavior = collision.GetComponent<EnemyBehavior>();
            behavior.speed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            manager.DeathCanvasDisable();
        }
    }

}
