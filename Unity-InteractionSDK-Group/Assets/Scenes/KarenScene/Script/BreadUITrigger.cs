using UnityEngine;

public class BreadUITrigger : MonoBehaviour
{
    public GameObject popupPanel;
    private bool alreadyShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyShown) return;

        if (other.gameObject.name.ToLower().Contains("hand") || other.CompareTag("Player"))
        {
            alreadyShown = true;
            popupPanel.SetActive(true);
            Debug.Log("POPUP ACTIVADO POR COLISIÓN");
        }
    }

    public void OnAddToBag()
	{
    Debug.Log("Bread added to bag!");

    // Close the popup
    if (popupPanel != null)
        popupPanel.SetActive(false);

    // Tell the BagManager to increase the count
    if (BagManager.Instance != null)
    {
        BagManager.Instance.AddItems(1);
    }
	}


    public void OnNoThanks()
    {
        popupPanel.SetActive(false);
        Debug.Log("No thanks");
    }
}
