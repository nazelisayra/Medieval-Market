using UnityEngine;
using System.Collections.Generic; // Required for Lists

[RequireComponent(typeof(AudioSource))] // Automatically adds an AudioSource if missing
public class ShopUI : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip coinSound;

    [Header("Shop Items")]
    // Drag all 4 of your food buttons (that have the ShopItem script) into this list
    public List<ShopItem> itemsInShop; 

    private void Start()
    {
        // Auto-find audio source if you forgot to drag it in
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    // Call this when the YES button is clicked
    public void BuyItem()
    {
        bool boughtSomething = false;

        // Loop through all items to see which ones are selected
        foreach (ShopItem item in itemsInShop)
        {
            if (item.isSelected)
            {
                item.ProcessPurchase();
                boughtSomething = true;
            }
        }

        // Only play sound if we actually bought something
        if (boughtSomething)
        {
            PlayCoinSound();
            Debug.Log("Items Purchased and removed!");
        }
        else
        {
            Debug.Log("Nothing selected to buy.");
        }
    }

    // Call this when the NO button is clicked
    public void CancelBuy()
    {
        Debug.Log("Purchase Cancelled");
        // Optional: Deselect everything if they press No
        foreach (ShopItem item in itemsInShop)
        {
            if (item.isSelected)
            {
                item.ToggleSelection(); // Flips it back to false and hides price
            }
        }
    }

    void PlayCoinSound()
    {
        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }
}