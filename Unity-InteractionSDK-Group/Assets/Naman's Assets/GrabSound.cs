using UnityEngine;

public class GrabSound : MonoBehaviour
{
    public AudioSource audioSource;
    private OVRGrabbable grabbable;
    private bool wasGrabbed = false;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        // When grab starts
        if (grabbable.isGrabbed && !wasGrabbed)
        {
            audioSource.Play();
            wasGrabbed = true;
        }

        // When released
        if (!grabbable.isGrabbed && wasGrabbed)
        {
            wasGrabbed = false;
        }
    }
}
