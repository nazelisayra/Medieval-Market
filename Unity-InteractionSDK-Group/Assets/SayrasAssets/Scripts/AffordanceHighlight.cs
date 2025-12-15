using UnityEngine;

public class AffordanceHighlight : MonoBehaviour
{
    public GameObject highlight; // child Highlight
    public AudioSource audioSource;
    public AudioClip hoverClip;

    void Awake()
    {
        if (highlight) highlight.SetActive(false);
    }

    // UnityEvent ile çağıracağız
    public void Show()
    {
        if (highlight) highlight.SetActive(true);
        if (audioSource && hoverClip) audioSource.PlayOneShot(hoverClip);
    }

    public void Hide()
    {
        if (highlight) highlight.SetActive(false);
    }
}
