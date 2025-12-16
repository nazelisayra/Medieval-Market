using UnityEngine;

public class BreadUITrigger : MonoBehaviour
{
    public GameObject popupPanel;
    public GameObject breadObject;      // this bread will be hidden

    [Header("FX when bread is added")]
    public ParticleSystem addEffect;    // Smoke puff
    public AudioSource addSound;        // Sound

    private bool alreadyShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyShown) return;

        if (other.gameObject.name.ToLower().Contains("hand") || other.CompareTag("Player"))
        {
            alreadyShown = true;

            if (popupPanel != null)
                popupPanel.SetActive(true);

            Debug.Log("POPUP ACTIVADO POR COLISIÓN");
        }
    }

    public void OnAddToBag()
    {
        Debug.Log("Bread added to bag!");

        // PLAY FX HERE (same click as Add)
        if (addEffect != null)
            addEffect.Play();

        if (addSound != null)
            addSound.Play();

        // Hide/remove the bread
        if (breadObject != null)
            breadObject.SetActive(false);

        if (popupPanel != null)
            popupPanel.SetActive(false);

        if (BagManager.Instance != null)
            BagManager.Instance.AddItems(1);
    }

    public void OnNoThanks()
    {
        if (popupPanel != null)
            popupPanel.SetActive(false);

        Debug.Log("No thanks");
    }
}
