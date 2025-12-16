using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject priceImage;   // Drag the "$4" UI image here

    [Header("3D Scene Setup")]
    public GameObject objectOnTable; // Drag the ACTUAL 3D food model (on the table) here
    public GameObject smokeEffectPrefab; 

    [HideInInspector]
    public bool isSelected = false;

    void Start()
    {
        // Ensure price is hidden at the start
        if (priceImage != null)
            priceImage.SetActive(false);
    }

    // Connect this to the Food Button's "On Click" event
    public void ToggleSelection()
    {
        isSelected = !isSelected;

        // Toggle the price visibility based on selection
        if (priceImage != null)
        {
            priceImage.SetActive(isSelected);
        }
    }

    // This is called by the ShopUI when "YES" is pressed
    public void ProcessPurchase()
    {
        // 1. Spawn Smoke at the TABLE OBJECT'S position (not the button)
        if (smokeEffectPrefab != null && objectOnTable != null)
        {
            Instantiate(smokeEffectPrefab, objectOnTable.transform.position, Quaternion.identity);
        }

        // 2. Hide the 3D item on the table
        if (objectOnTable != null)
        {
            objectOnTable.SetActive(false);
        }

        // 3. Reset logic (hide price and deselect)
        isSelected = false;
        
        if (priceImage != null) 
            priceImage.SetActive(false);
    }
}