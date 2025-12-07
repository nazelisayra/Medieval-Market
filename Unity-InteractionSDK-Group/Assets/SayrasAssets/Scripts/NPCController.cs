using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Animator npcAnimator;

    [Header("UI Elements")]
    public GameObject infoCardUI; // Inspector'dan atayacağımız UI Canvas

    void Start()
    {
        npcAnimator = GetComponent<Animator>();

        // Oyun başladığında UI kartını gizle
        if (infoCardUI != null)
        {
            infoCardUI.SetActive(false);
        }
    }

    // Oyuncu alana girdiğinde çalışır (Trigger Enter)
    void OnTriggerEnter(Collider other)
    {
        // Giren objenin etiketi "Player" mı?
        if (other.CompareTag("Player"))
        {
            // Animasyonu konuşma moduna al
            npcAnimator.SetBool("isTalking", true);

            // UI kartını göster
            if (infoCardUI != null)
            {
                infoCardUI.SetActive(true);
            }
        }
    }

    // Oyuncu alandan çıktığında çalışır (Trigger Exit)
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Animasyonu bekleme moduna al
            npcAnimator.SetBool("isTalking", false);

            // UI kartını gizle
            if (infoCardUI != null)
            {
                infoCardUI.SetActive(false);
            }
        }
    }
}