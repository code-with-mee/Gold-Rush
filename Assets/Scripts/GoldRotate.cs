using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GoldRotate : MonoBehaviour
{
    [SerializeField] private float speed = 100;

    private UIManager uiManager = null;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name} Hit Player");
            GoldRotate[] golds = FindObjectsByType<GoldRotate>(FindObjectsSortMode.None);
            if (golds != null && golds.Length == 1)
            {
                Debug.Log("Winning.");
                uiManager.ShowWinLoseScreen("LEVEL COMPLETED!");
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (golds != null)
            {
                Debug.LogWarning("Gold remain : " + golds.Length);
            }
            
            if (uiManager != null)
                uiManager.RefreshGoldHitCount();
            Destroy(gameObject);
        }
    }
}
