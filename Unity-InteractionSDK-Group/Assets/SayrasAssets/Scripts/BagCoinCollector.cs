using System.Collections.Generic;
using UnityEngine;

public class BagCoinCollector : MonoBehaviour
{
    [Header("References")]
    public AudioSource audioSource;
    public AudioClip coinDropClip;
    public ParticleSystem coinFx;

    [Header("UI")]
    public GameObject congratsUI;          // (Fallback) CongratsCardCanvas
    public UIRevealTween congratsTween;    // (Preferred) UIRevealTween component

    [Header("Coin Settings")]
    public int requiredCoins = 3;

    [Tooltip("Optional: coins snap points inside the bag (size >= requiredCoins).")]
    public Transform[] snapSlots;

    private readonly HashSet<CoinCollectable> collectedCoins = new HashSet<CoinCollectable>();

    void Start()
    {
        if (congratsUI) congratsUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Coin")) return;

        CoinCollectable coin = other.GetComponent<CoinCollectable>();
        if (!coin) coin = other.GetComponentInParent<CoinCollectable>();
        if (!coin) return;

        if (coin.collected) return;

        coin.collected = true;
        collectedCoins.Add(coin);

        if (audioSource && coinDropClip)
            audioSource.PlayOneShot(coinDropClip);

        if (coinFx)
        {
            coinFx.transform.position = coin.transform.position;
            coinFx.Play();
        }

        SnapCoin(coin);

        if (collectedCoins.Count >= requiredCoins)
        {
            if (congratsTween != null)
                congratsTween.Show();
            else if (congratsUI != null)
                congratsUI.SetActive(true);
        }
    }

    void SnapCoin(CoinCollectable coin)
    {
        Rigidbody rb = coin.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Collider col = coin.GetComponent<Collider>();
        if (col) col.enabled = false;

        int idx = collectedCoins.Count - 1;

        if (snapSlots != null && snapSlots.Length > idx && snapSlots[idx] != null)
        {
            coin.transform.SetParent(snapSlots[idx], true);
            coin.transform.position = snapSlots[idx].position;
            coin.transform.rotation = snapSlots[idx].rotation;
        }
        else
        {
            coin.transform.SetParent(transform, true);
            coin.transform.position = transform.position + new Vector3(0, 0.02f * idx, 0);
        }
    }
}
