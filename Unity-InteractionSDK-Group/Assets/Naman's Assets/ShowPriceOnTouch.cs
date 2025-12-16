using UnityEngine;

public class ShowPriceOnTouch : MonoBehaviour
{
    public GameObject priceUI;   // Assign the canvas here

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hand"))
        {
            priceUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Hand"))
        {
            priceUI.SetActive(false);
        }
    }
}
