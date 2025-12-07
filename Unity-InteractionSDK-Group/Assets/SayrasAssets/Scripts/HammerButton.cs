using System.Collections;
using UnityEngine;

public class HammerButton : MonoBehaviour
{
    [Header("Feedback")]
    public AudioSource audioSource;
    public ParticleSystem hitEffect;
    public Transform buttonVisual;   // hareket edecek kısım (yoksa kendisi)

    [Header("Settings")]
    public string hammerTag = "Hammer";
    public float pressDepth = 0.02f;
    public float pressDuration = 0.1f;
    public float resetDelay = 0.3f;

    private Vector3 _initialLocalPos;
    private bool _isPressed;

    private void Start()
    {
        if (buttonVisual == null)
            buttonVisual = transform;

        _initialLocalPos = buttonVisual.localPosition;

        // ✅ Başlangıçta kesinlikle ses ve VFX çalışmasın
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.Stop();
        }

        if (hitEffect != null)
        {
            hitEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPressed)
            return;

        Transform t = collision.transform;

        if (!t.CompareTag(hammerTag) && !t.root.CompareTag(hammerTag))
            return;

        PressButton();
    }

    private void PressButton()
    {
        _isPressed = true;

        if (audioSource != null)
            audioSource.Play();

        if (hitEffect != null)
            hitEffect.Play();

        StopAllCoroutines();
        StartCoroutine(AnimatePress());
    }

    private IEnumerator AnimatePress()
    {
        Vector3 downPos = _initialLocalPos + Vector3.down * pressDepth;

        // Aşağı in
        float t = 0f;
        while (t < pressDuration)
        {
            t += Time.deltaTime;
            float k = t / pressDuration;
            buttonVisual.localPosition = Vector3.Lerp(_initialLocalPos, downPos, k);
            yield return null;
        }

        yield return new WaitForSeconds(resetDelay);

        // Yukarı çık
        t = 0f;
        while (t < pressDuration)
        {
            t += Time.deltaTime;
            float k = t / pressDuration;
            buttonVisual.localPosition = Vector3.Lerp(downPos, _initialLocalPos, k);
            yield return null;
        }

        // Eğer VFX looping ise burada kapatmak iyi olur
        if (hitEffect != null)
        {
            hitEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        _isPressed = false;
    }
}
