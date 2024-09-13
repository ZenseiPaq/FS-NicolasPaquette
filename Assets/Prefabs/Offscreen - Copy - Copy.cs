using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffscreenChecker : MonoBehaviour
{
    private GameManager gameManager;
    private Camera mainCamera;

    public void Initialize(GameManager manager, Camera camera)
    {
        gameManager = manager;
        mainCamera = camera;
        Debug.Log("EnemyOffscreenChecker initialized with GameManager and Camera.");
    }

    void Update()
    {
        if (gameManager == null || mainCamera == null)
        {
            Debug.LogError("EnemyOffscreenChecker not initialized properly.");
            return;
        }

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }
}